using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        private IContext _db;

        public AnswerRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<Answer> GetAll()
        {
            return _db.Answers;
        }

        public Answer Get(int id)
        {
            return _db.Answers.Find(id);
        }

        public void Create(Answer answer)
        {
            _db.Answers.Add(answer);
        }

        public void Update(Answer answer)
        {
            _db.SetModified(answer);
        }

        public void Delete(int id)
        {
            Answer answer = _db.Answers.Find(id);
            if (answer != null)
                _db.Answers.Remove(answer);
        }
    }
}