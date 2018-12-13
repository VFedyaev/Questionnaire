using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.DAL.Entities;

namespace Questionnaire.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<QuestionType> QuestionTypes { get; }
        IRepository<Question> Questions { get; }
        IRepository<Answer> Answers { get; }
        IRepository<QuestionAnswer> QuestionAnswers { get; }
        IRepository<SurveyGeography> SurveyGeographies { get; }
        IRepository<HousingType> HousingTypes { get; }
        IRepository<District> Districts { get; }
        IRepository<Interviewer> Interviewers { get; }
        IRepository<Form> Forms { get; }
        IRepository<Family> Families { get; }
        IRepository<Data> Datas { get; }

        void Save();
    }
}
