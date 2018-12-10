using Questionnaire.WEB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.WEB.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        QuestionTypeRepository QuestionTypes { get; }
        QuestionRepository Questions { get; }
        AnswerRepository Answers { get; }
        QuestionAnswerRepository QuestionAnswers { get; }
        SurveyGeographyRepository SurveyGeographies { get; }
        HousingTypeRepository HousingTypes { get; }
        DistrictRepository Districts { get; }
        InterviewerRepository Interviewers { get; }
        FormRepository Forms { get; }
        FamilyRepository Families { get; }
        DataRepository Datas { get; }

        void Save();
    }
}
