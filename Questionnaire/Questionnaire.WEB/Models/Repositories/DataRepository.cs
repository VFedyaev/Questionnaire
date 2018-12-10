using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class DataRepository : IRepository<Data>
    {
        private IContext _db;

        public DataRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<Data> GetAll()
        {
            return _db.Datas;
        }

        public Data Get(int id)
        {
            return _db.Datas.Find(id);
        }

        public void Create(Data data)
        {
            _db.Datas.Add(data);
        }

        public void Update(Data data)
        {
            _db.SetModified(data);
        }

        public void Delete(int id)
        {
            Data data = _db.Datas.Find(id);
            if (data != null)
                _db.Datas.Remove(data);
        }
    }
}