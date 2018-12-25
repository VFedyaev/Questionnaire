using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Infrastructure.Exceptions;
using Questionnaire.BLL.Interfaces;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public class QuestionAnswerService : IQuestionAnswerService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public QuestionAnswerService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public QuestionAnswerDTO Get(int id)
        {
            QuestionAnswer questionAnswer = _unitOfWork.QuestionAnswers.Get(id);

            return Mapper.Map<QuestionAnswerDTO>(questionAnswer);
        }

        public IEnumerable<QuestionAnswerDTO> GetAll()
        {
            List<QuestionAnswer> questionAnswers = _unitOfWork
                .QuestionAnswers
                .GetAll()
                .ToList();

            return Mapper.Map<IEnumerable<QuestionAnswerDTO>>(questionAnswers);
        }

        public void Create(int questionId, int answerId)
        {
            QuestionAnswerDTO questionAnswerDTO = new QuestionAnswerDTO
            {
                QuestionId = questionId,
                AnswerId = answerId
            };
            this.Add(questionAnswerDTO);
        }

        public void Add(QuestionAnswerDTO questionAnswerDTO)
        {
            QuestionAnswer relation = Mapper.Map<QuestionAnswer>(questionAnswerDTO);

            _unitOfWork.QuestionAnswers.Create(relation);
            _unitOfWork.Save();
        }

        public void Update(QuestionAnswerDTO item)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestionRelations(int? questId, string[] answerIds)
        {
            if (questId == null)
                throw new ArgumentNullException();
            int questionId = (int)questId;

            if (answerIds.Length <= 0)
            {
                DeleteRelationsByQuestionId(questionId);
                return;
            }

            UpdateQuestionRelations(questionId, answerIds);
        }
        public void DeleteRelationsByQuestionId(int id)
        {
            IEnumerable<int> relationIds = _unitOfWork
                .QuestionAnswers
                .Find(r => r.QuestionId == id)
                .Select(r => r.Id)
                .ToList();

            foreach (int relationId in relationIds)
                Delete(relationId);
        }

        private void UpdateQuestionRelations(int questionId, string[] answerIds)
        {
            List<int> questionAnswerIds = _unitOfWork
                .QuestionAnswers
                .Find(r => r.QuestionId == questionId)
                .Select(r => r.AnswerId)
                .ToList();

            List<int> guidAnswerIds = answerIds
                .Select(id => int.Parse(id))
                .ToList();

            foreach (int answerId in guidAnswerIds)
                if (!questionAnswerIds.Contains(answerId))
                    Create(questionId, answerId);

            foreach (int questionAnswerId in questionAnswerIds)
                if (!guidAnswerIds.Contains(questionAnswerId))
                    DeleteEquipmentRelation(questionId, questionAnswerId);
        }

        private void DeleteEquipmentRelation(int questionId, int answerId)
        {
            QuestionAnswer relation = _unitOfWork
                .QuestionAnswers
                .Find(r => r.QuestionId == questionId && r.AnswerId == answerId)
                .FirstOrDefault();

            if (relation != null)
                Delete(relation.Id);
        }

        public IEnumerable<FormDataDTO> GetQuestionAnswersByQuestionType(int questionTypeId)
        {
            var formData = (
                from
                    questionAnswer in _unitOfWork.QuestionAnswers.GetAll()
                join
                    question in _unitOfWork.Questions.GetAll()
                on
                    questionAnswer.QuestionId equals question.Id
                join
                    answer in _unitOfWork.Answers.GetAll()
                on
                    questionAnswer.AnswerId equals answer.Id
                join
                    questionType in _unitOfWork.QuestionTypes.GetAll()
                on
                    question.QuestionTypeId equals questionType.Id
                where questionType.Id == questionTypeId
                orderby questionTypeId
                select new
                {
                    questionAnswerId = questionAnswer.Id,
                    questionName = question.Name,
                    answerName = answer.Name,
                    multipleAnswer = question.MultipleAnswer

                } into result
                group result by new { result.questionName } into data
                select new FormDataDTO
                {
                    QuestionName = data.Key.questionName,
                    Options = data.Select(o =>
                    {
                        return new FormOptionDTO
                        {
                            Id = o.questionAnswerId,
                            Name = o.answerName,
                            MultipleAnswer = o.multipleAnswer
                        };
                    })
                }).ToList();

            //var sortedData = (
            //    from data in unsortedData
            //    select new FormDataDTO
            //    {
            //        QuestionName = data.Key.questionName,
            //        Options = data.Select(o =>
            //        {
            //            return new FormOptionDTO
            //            {
            //                Id = o.questionAnswerId,
            //                Name = o.answerName
            //            };
            //        })
            //    });

            //select new FormDataDTO
            //{
            //    QuestionTypeName = groupedResult.Key.questionTypeName,
            //    Questions = groupedResult.Select(q =>
            //    {
            //        return new FormQuestionDTO
            //        {
            //            Name = q.questionName,
            //            Options = groupedResult.Select(o =>
            //            {
            //                return new FormOptionDTO
            //                {
            //                    Id = o.questionAnswerId,
            //                    Name = o.answerName
            //                };
            //            })
            //        };
            //    })
            //}

            return formData.OrderBy(x=> x.QuestionName);
        }

        public void Delete(int id)
        {
            QuestionAnswer relation = _unitOfWork.QuestionAnswers.Get(id);
            if (relation == null)
                throw new NotFoundException();

            _unitOfWork.QuestionAnswers.Delete(id);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
