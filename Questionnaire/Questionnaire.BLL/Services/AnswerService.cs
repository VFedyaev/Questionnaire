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
    public class AnswerService : IAnswerService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public AnswerService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public AnswerDTO Get(int id)
        {
            Answer answer = _unitOfWork.Answers.Get(id);

            return Mapper.Map<AnswerDTO>(answer);
        }

        public AnswerDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Answer answer = _unitOfWork.Answers.Get(id);
            if (answer == null)
                throw new NotFoundException();

            return Mapper.Map<AnswerDTO>(answer);
        }

        public IEnumerable<AnswerDTO> GetAll()
        {
            List<Answer> answers = _unitOfWork.Answers.GetAll().ToList();

            return Mapper.Map<IEnumerable<AnswerDTO>>(answers);
        }

        public IEnumerable<AnswerDTO> GetListOrderedByName()
        {
            List<Answer> answers = _unitOfWork.Answers.GetAll().OrderBy(n => n.Name).ToList();

            return Mapper.Map<IEnumerable<AnswerDTO>>(answers);
        }

        public void Add(AnswerDTO answerDTO)
        {
            try
            {
                Answer answer = Mapper.Map<Answer>(answerDTO);
                _unitOfWork.Answers.Create(answer);
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (NotUnique(answerDTO.Name))
                    throw new UniqueConstraintException();
            }

        }

        public void Update(AnswerDTO answerDTO)
        {
            try
            {
                Answer answer = Mapper.Map<Answer>(answerDTO);

                _unitOfWork.Answers.Update(answer);
                _unitOfWork.Save();
            }
            catch (DbUpdateException)
            {
                if (NotUnique(answerDTO.Name))
                    throw new UniqueConstraintException();
            }

        }


        public void Delete(int id)
        {
            if (HasRelations(id))
                throw new HasRelationsException();

            Answer answer = _unitOfWork.Answers.Get(id);
            if (answer == null)
                throw new NotFoundException();

            _unitOfWork.Answers.Delete(id);
            _unitOfWork.Save();
        }

        public bool NotUnique(string name)
        {
            var relationsCount = _unitOfWork.Answers.Find(h => h.Name == name).ToList().Count();
            return relationsCount > 0;
        }

        public IEnumerable<AnswerDTO> GetAnswersBy(string type, string value)
        {
            IEnumerable<AnswerDTO> answers = Enumerable.Empty<AnswerDTO>();
            switch (type)
            {
                case "model":
                    answers = GetAnswersByModel(value);
                    break;

            }

            return answers;
        }
        private IEnumerable<AnswerDTO> GetAnswersByModel(string value)
        {
            IEnumerable<Answer> answers = _unitOfWork
                .Answers
                .Find(c => c.Name.ToLower().Contains(value));

            if (answers.Count() <= 0)
                return Enumerable.Empty<AnswerDTO>();

            return Mapper.Map<IEnumerable<AnswerDTO>>(answers);
        }

        public bool HasRelations(int id)
        {
            var relations = _unitOfWork.QuestionAnswers.Find(h => h.AnswerId == id);

            return relations.Count() > 0;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
