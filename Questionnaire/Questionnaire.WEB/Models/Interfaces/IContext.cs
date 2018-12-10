using Questionnaire.WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.WEB.Models.Interfaces
{
    public interface IContext
    {
        IDbSet<QuestionType> QuestionTypes { get; set; }
        IDbSet<Question> Questions { get; set; }
        IDbSet<Answer> Answers { get; set; }
        IDbSet<QuestionAnswer> QuestionAnswers { get; set; }
        IDbSet<SurveyGeography> SurveyGeographies { get; set; }
        IDbSet<HousingType> HousingTypes { get; set; }
        IDbSet<District> Districts { get; set; }
        IDbSet<Interviewer> Interviewers { get; set; }
        IDbSet<Form> Forms { get; set; }
        IDbSet<Family> Families { get; set; }
        IDbSet<Data> Datas { get; set; }

        void SetModified(object entity);
        void Save();
        void DbDispose();
    }
}
