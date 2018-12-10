using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class QuestionTypeRepository : IRepository<QuestionType>
    {
        private IContext _db;

        public QuestionTypeRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<QuestionType> GetAll()
        {
            return _db.QuestionTypes;
        }

        public QuestionType Get(int id)
        {
            return _db.QuestionTypes.Find(id);
        }

        public void Create(QuestionType questionType)
        {
            _db.QuestionTypes.Add(questionType);
        }

        public void Update(QuestionType questionType)
        {
            _db.SetModified(questionType);
        }

        public void Delete(int id)
        {
            QuestionType questionType = _db.QuestionTypes.Find(id);
            if (questionType != null)
                _db.QuestionTypes.Remove(questionType);
        }
    }
}