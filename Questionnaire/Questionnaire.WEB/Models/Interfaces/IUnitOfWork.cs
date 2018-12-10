using Questionnaire.WEB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.WEB.Models.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        QuestionTypeRepository QuestionTypes { get; set; }
        QuestionRepository Questions { get; set; }
        AnswerRepository Answers { get; set; }
        QuestionAnswerRepository QuestionAnswers { get; set; }
        SurveyGeographyRepository SurveyGeographies { get; set; }
        HousingTypeRepository HousingTypes { get; set; }
        DistrictRepository Districts { get; set; }
        InterviewerRepository Interviewers { get; set; }
        FormRepository Forms { get; set; }
        FamilyRepository Families { get; set; }
        DataRepository Datas { get; set; }

        void Save();
    }
}
