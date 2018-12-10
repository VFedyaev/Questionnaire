using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class HousingTypeRepository : IRepository<HousingType>
    {
        private IContext _db;

        public HousingTypeRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<HousingType> GetAll()
        {
            return _db.HousingTypes;
        }

        public HousingType Get(int id)
        {
            return _db.HousingTypes.Find(id);
        }

        public void Create(HousingType housingType)
        {
            _db.HousingTypes.Add(housingType);
        }

        public void Update(HousingType housingType)
        {
            _db.SetModified(housingType);
        }

        public void Delete(int id)
        {
            HousingType housingType = _db.HousingTypes.Find(id);
            if (housingType != null)
                _db.HousingTypes.Remove(housingType);
        }
    }
}