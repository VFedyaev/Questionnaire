using Questionnaire.WEB.Models.Interfaces;
using Questionnaire.WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Questionnaire.WEB.Models.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private IContext _db;

        public QuestionRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<Question> GetAll()
        {
            return _db.Questions.Include(qt => qt.QuestionType);
        }

        public Question Get(int id)
        {
            return _db.Questions.Find(id);
        }

        public void Create(Question question)
        {
            _db.Questions.Add(question);
        }

        public void Update(Question question)
        {
            _db.SetModified(question);
        }

        public void Delete(int id)
        {
            Question question = _db.Questions.Find(id);
            if (question != null)
                _db.Questions.Remove(question);
        }
    }
}