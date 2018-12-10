using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class FormRepository : IRepository<Form>
    {
        private IContext _db;

        public FormRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<Form> GetAll()
        {
            return _db.Forms;
        }

        public Form Get(int id)
        {
            return _db.Forms.Find(id);
        }

        public void Create(Form form)
        {
            _db.Forms.Add(form);
        }

        public void Update(Form form)
        {
            _db.SetModified(form);
        }

        public void Delete(int id)
        {
            Form form = _db.Forms.Find(id);
            if (form != null)
                _db.Forms.Remove(form);
        }
    }
}