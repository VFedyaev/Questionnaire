using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.Repositories
{
    public class SurveyGeographyRepository : IRepository<SurveyGeography>
    {
        private IContext _db;

        public SurveyGeographyRepository(IContext context)
        {
            this._db = context;
        }

        public IEnumerable<SurveyGeography> GetAll()
        {
            return _db.SurveyGeographies;
        }

        public SurveyGeography Get(int id)
        {
            return _db.SurveyGeographies.Find(id);
        }

        public void Create(SurveyGeography surveyGeography)
        {
            _db.SurveyGeographies.Add(surveyGeography);
        }

        public void Update(SurveyGeography surveyGeography)
        {
            _db.SetModified(surveyGeography);
        }

        public void Delete(int id)
        {
            SurveyGeography surveyGeography = _db.SurveyGeographies.Find(id);
            if (surveyGeography != null)
                _db.SurveyGeographies.Remove(surveyGeography);
        }
    }
}