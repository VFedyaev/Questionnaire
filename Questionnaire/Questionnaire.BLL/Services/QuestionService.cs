using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Infrastructure.Exceptions;
using Questionnaire.BLL.Interfaces;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public QuestionService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public QuestionDTO Get(int id)
        {
            Question question = _unitOfWork.Questions.Get(id);

            return Mapper.Map<QuestionDTO>(question);
        }

        public QuestionDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Question question = _unitOfWork.Questions.Get(id);
            if (question == null)
                throw new NotFoundException();

            return Mapper.Map<QuestionDTO>(question);
        }

        public IEnumerable<QuestionDTO> GetAll()
        {
            List<Question> questions = _unitOfWork.Questions.GetAll().ToList();

            return Mapper.Map<IEnumerable<QuestionDTO>>(questions);
        }

        public IEnumerable<QuestionDTO> GetListOrderedByName()
        {
            List<Question> questions = _unitOfWork.Questions.GetAll().OrderBy(n => n.Name).ToList();

            return Mapper.Map<IEnumerable<QuestionDTO>>(questions);
        }

        public void Add(QuestionDTO questionDTO)
        {
            try
            {
                Question question = Mapper.Map<Question>(questionDTO);
                _unitOfWork.Questions.Create(question);
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (NotUnique(questionDTO.Name))
                    throw new UniqueConstraintException();
            }
        }

        public void Update(QuestionDTO questionDTO)
        {
            try
            {
                Question question = Mapper.Map<Question>(questionDTO);

                _unitOfWork.Questions.Update(question);
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (NotUnique(questionDTO.Name))
                    throw new UniqueConstraintException();
            }

        }

        public bool NotUnique(string name)
        {
            var relationsCount = _unitOfWork.Questions.Find(h => h.Name == name).ToList().Count();
            return relationsCount > 0;
        }

        public IEnumerable<AnswerDTO> GetAnswers(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            IEnumerable<int> questionAnswerIds = _unitOfWork
                .QuestionAnswers
                .Find(e => e.QuestionId == id)
                .Select(com => com.AnswerId);

            if (questionAnswerIds.Count() < 0)
                return Enumerable.Empty<AnswerDTO>();

            IEnumerable<AnswerDTO> answers = (
                from
                    relation in _unitOfWork.QuestionAnswers.GetAll()
                join
                    answer in _unitOfWork.Answers.GetAll()
                on
                    relation.AnswerId equals answer.Id
                where
                    relation.QuestionId == id
                select new AnswerDTO
                {
                    Id = answer.Id,
                    Name = answer.Name,
                });

            return answers;
        }

        public void Delete(int id)
        {
            if (HasRelations(id))
                throw new HasRelationsException();

            Question question = _unitOfWork.Questions.Get(id);
            if (question == null)
                throw new NotFoundException();

            _unitOfWork.Questions.Delete(id);
            _unitOfWork.Save();
        }

        public bool HasRelations(int id)
        {
            var relations = _unitOfWork.QuestionAnswers.Find(h => h.QuestionId == id);

            return relations.Count() > 0;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
