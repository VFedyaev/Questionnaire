using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;

namespace Questionnaire.WEB.Models.Context
{
    public class QuestionnaireContext : DbContext, IContext
    {
        public QuestionnaireContext() : base("QuestionnaireDB")
        {
        }

        public QuestionnaireContext(string connectionString) : base(connectionString)
        {
        }

        public IDbSet<QuestionType> QuestionTypes { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<Answer> Answers { get; set; }
        public IDbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public IDbSet<SurveyGeography> SurveyGeographies { get; set; }
        public IDbSet<HousingType> HousingTypes { get; set; }
        public IDbSet<District> Districts { get; set; }
        public IDbSet<Interviewer> Interviewers { get; set; }
        public IDbSet<Form> Forms { get; set; }
        public IDbSet<Family> Families { get; set; }
        public IDbSet<Data> Datas { get; set; }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            SaveChanges();
        }

        public void DbDispose()
        {
            Dispose();
        }
    }
}