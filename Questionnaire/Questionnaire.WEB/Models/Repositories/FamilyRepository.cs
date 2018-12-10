using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class FamilyRepository : IRepository<Family>
    {
        private IContext _db;

        public FamilyRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<Family> GetAll()
        {
            return _db.Families;
        }

        public Family Get(int id)
        {
            return _db.Families.Find(id);
        }

        public void Create(Family family)
        {
            _db.Families.Add(family);
        }

        public void Update(Family family)
        {
            _db.SetModified(family);
        }

        public void Delete(int id)
        {
            Family family = _db.Families.Find(id);
            if (family != null)
                _db.Families.Remove(family);
        }
    }
}