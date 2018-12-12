using Ninject.Modules;
using Questionnaire.BLL.Interfaces;
using Questionnaire.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Util
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IQuestionTypeService>().To<QuestionTypeService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<IAnswerService>().To<AnswerService>();
            Bind<IQuestionAnswerService>().To<QuestionAnswerService>();
            Bind<ISurveyGeographyService>().To<SurveyGeographyService>();
            Bind<IHousingTypeService>().To<HousingTypeService>();
            Bind<IDistrictService>().To<DistrictService>();
            Bind<IInterviewerService>().To<InterviewerService>();
            Bind<IFormService>().To<FormService>();
            Bind<IFamilyService>().To<FamilyService>();
            Bind<IDataService>().To<DataService>();

            Bind<IAccountService>().To<AccountService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}