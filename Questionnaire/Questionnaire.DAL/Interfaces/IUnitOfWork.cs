using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Identity;

namespace Questionnaire.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

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

        Task SaveAsync();
        void Save();
    }
}
