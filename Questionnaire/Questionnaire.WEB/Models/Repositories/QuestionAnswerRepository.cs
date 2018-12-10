using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class QuestionAnswerRepository : IRepository<QuestionAnswer>
    {
        private IContext _db;

        public QuestionAnswerRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<QuestionAnswer> GetAll()
        {
            return _db.QuestionAnswers;
        }

        public QuestionAnswer Get(int id)
        {
            return _db.QuestionAnswers.Find(id);
        }

        public void Create(QuestionAnswer questionAnswer)
        {
            _db.QuestionAnswers.Add(questionAnswer);
        }

        public void Update(QuestionAnswer questionAnswer)
        {
            _db.SetModified(questionAnswer);
        }

        public void Delete(int id)
        {
            QuestionAnswer questionAnswer = _db.QuestionAnswers.Find(id);
            if (questionAnswer != null)
                _db.QuestionAnswers.Remove(questionAnswer);
        }
    }
}