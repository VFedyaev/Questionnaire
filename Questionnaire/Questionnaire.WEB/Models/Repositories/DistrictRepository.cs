using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class DistrictRepository : IRepository<District>
    {
        private IContext _db;

        public DistrictRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<District> GetAll()
        {
            return _db.Districts;
        }

        public District Get(int id)
        {
            return _db.Districts.Find(id);
        }

        public void Create(District district)
        {
            _db.Districts.Add(district);
        }

        public void Update(District district)
        {
            _db.SetModified(district);
        }

        public void Delete(int id)
        {
            District district = _db.Districts.Find(id);
            if (district != null)
                _db.Districts.Remove(district);
        }
    }
}