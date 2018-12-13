using Questionnaire.DAL.EF;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseRepository<QuestionType> questionTypeRepository;
        private BaseRepository<Question> questionRepository;
        private BaseRepository<Answer> answerRepository;
        private BaseRepository<QuestionAnswer> questionAnswerRepository;
        private BaseRepository<SurveyGeography> surveyGeographyRepository;
        private BaseRepository<HousingType> housingTypeRepository;
        private BaseRepository<District> districtRepository;
        private BaseRepository<Interviewer> interviewerRepository;
        private BaseRepository<Form> formRepository;
        private BaseRepository<Family> familyRepository;
        private BaseRepository<Data> dataRepository;

        private QuestionnaireContext context;

        public UnitOfWork(string connectionString)
        {
            context = new QuestionnaireContext(connectionString);
        }

        public IRepository<QuestionType> QuestionTypes
        {
            get
            {
                if (questionTypeRepository == null)
                    questionTypeRepository = new BaseRepository<QuestionType>(context);
                return questionTypeRepository;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new BaseRepository<Question>(context);
                return questionRepository;
            }
        }

        public IRepository<Answer> Answers
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new BaseRepository<Answer>(context);
                return answerRepository;
            }
        }

        public IRepository<QuestionAnswer> QuestionAnswers
        {
            get
            {
                if (questionAnswerRepository == null)
                    questionAnswerRepository = new BaseRepository<QuestionAnswer>(context);
                return questionAnswerRepository;
            }
        }

        public IRepository<SurveyGeography> SurveyGeographies
        {
            get
            {
                if (surveyGeographyRepository == null)
                    surveyGeographyRepository = new BaseRepository<SurveyGeography>(context);
                return surveyGeographyRepository;
            }
        }

        public IRepository<HousingType> HousingTypes
        {
            get
            {
                if (housingTypeRepository == null)
                    housingTypeRepository = new BaseRepository<HousingType>(context);
                return housingTypeRepository;
            }
        }

        public IRepository<District> Districts
        {
            get
            {
                if (districtRepository == null)
                    districtRepository = new BaseRepository<District>(context);
                return districtRepository;
            }
        }

        public IRepository<Interviewer> Interviewers
        {
            get
            {
                if (interviewerRepository == null)
                    interviewerRepository = new BaseRepository<Interviewer>(context);
                return interviewerRepository;
            }
        }

        public IRepository<Form> Forms
        {
            get
            {
                if (formRepository == null)
                    formRepository = new BaseRepository<Form>(context);
                return formRepository;
            }
        }

        public IRepository<Family> Families
        {
            get
            {
                if (familyRepository == null)
                    familyRepository = new BaseRepository<Family>(context);
                return familyRepository;
            }
        }

        public IRepository<Data> Datas
        {
            get
            {
                if (dataRepository == null)
                    dataRepository = new BaseRepository<Data>(context);
                return dataRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    context.Dispose();
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
