using AutoMapper;
using Moq;
using Questionnaire.BLL.Services;
using Questionnaire.BLL.Tests.MappingProfiles;
using Questionnaire.BLL.Tests.MoqRepositories;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Tests.Services.Tests
{
    public class BaseInit
    {
        /* Moq Repositories */
        public MoqBaseRepository<QuestionType> moqQuestionTypeRepository;

        /* Moq UnitOfWork */
        public Mock<IUnitOfWork> moqUnitOfWork;

        /* Services */
        public QuestionTypeService QuestionTypeService;

        public void QuestionTypeInitialize()
        {
            SetupMapper();
            SetupQuestionTypeMoqRepositories();
            SetupQuestionTypeMoqUnitOfWork();
            SetupQuestionTypeServices();
        }

        public void SetupMapper()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg=> cfg.AddProfile<AutoMapperProfile>());
        }

        public void SetupQuestionTypeMoqRepositories()
        {
            moqQuestionTypeRepository = new MoqBaseRepository<QuestionType>(TestData.QuestionTypes);
        }

        public void SetupQuestionTypeMoqUnitOfWork()
        {
            moqUnitOfWork = new Mock<IUnitOfWork>();
            /* component */
            moqUnitOfWork
                .Setup(u => u.QuestionTypes)
                .Returns(moqQuestionTypeRepository.repository.Object);
        }
        public void SetupQuestionTypeServices()
        {
            QuestionTypeService = new QuestionTypeService(moqUnitOfWork.Object);
        }
    }
}
