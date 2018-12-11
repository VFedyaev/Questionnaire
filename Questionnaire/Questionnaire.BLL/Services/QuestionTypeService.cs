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
    public class QuestionTypeService : IQuestionTypeService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public QuestionTypeService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public QuestionTypeDTO Get(int id)
        {
            QuestionType questionType = _unitOfWork.QuestionTypes.Get(id);

            return Mapper.Map<QuestionTypeDTO>(questionType);
        }

        public QuestionTypeDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            QuestionType questionType = _unitOfWork.QuestionTypes.Get(id);
            if (questionType == null)
                throw new NotFoundException();

            return Mapper.Map<QuestionTypeDTO>(questionType);
        }

        public IEnumerable<QuestionTypeDTO> GetAll()
        {
            List<QuestionType> questionTypes = _unitOfWork.QuestionTypes.GetAll().ToList();

            return Mapper.Map<IEnumerable<QuestionTypeDTO>>(questionTypes);
        }

        public IEnumerable<QuestionTypeDTO> GetListOrderedByName()
        {
            List<QuestionType> questionTypes = _unitOfWork.QuestionTypes.GetAll().OrderBy(n => n.Name).ToList();

            return Mapper.Map<IEnumerable<QuestionTypeDTO>>(questionTypes);
        }

        public void Add(QuestionTypeDTO questionTypeDTO)
        {
            QuestionType questionType = Mapper.Map<QuestionType>(questionTypeDTO);
            _unitOfWork.QuestionTypes.Create(questionType);
            _unitOfWork.Save();
        }

        public void Update(QuestionTypeDTO questionTypeDTO)
        {
            QuestionType questionType = Mapper.Map<QuestionType>(questionTypeDTO);

            _unitOfWork.QuestionTypes.Update(questionType);
            _unitOfWork.Save();
        }


        public void Delete(int id)
        {
            if (HasRelations(id))
                throw new HasRelationsException();

            _unitOfWork.QuestionTypes.Delete(id);
            _unitOfWork.Save();
        }

        public bool HasRelations(int id)
        {
            var relations = _unitOfWork.Questions.Find(h => h.QuestionTypeId == id);

            return relations.Count() > 0;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
