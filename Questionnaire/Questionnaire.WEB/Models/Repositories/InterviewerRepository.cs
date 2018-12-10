using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class InterviewerRepository : IRepository<Interviewer>
    {
        private IContext _db;

        public InterviewerRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<Interviewer> GetAll()
        {
            return _db.Interviewers;
        }

        public Interviewer Get(int id)
        {
            return _db.Interviewers.Find(id);
        }

        public void Create(Interviewer interviewer)
        {
            _db.Interviewers.Add(interviewer);
        }

        public void Update(Interviewer interviewer)
        {
            _db.SetModified(interviewer);
        }

        public void Delete(int id)
        {
            Interviewer interviewer = _db.Interviewers.Find(id);
            if (interviewer != null)
                _db.Interviewers.Remove(interviewer);
        }
    }
}