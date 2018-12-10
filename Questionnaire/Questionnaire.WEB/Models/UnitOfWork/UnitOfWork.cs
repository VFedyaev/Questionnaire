using Questionnaire.WEB.Models.Context;
using Questionnaire.WEB.Models.Interfaces;
using Questionnaire.WEB.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Questionnaire.WEB.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IContext _db;

        private QuestionTypeRepository QuestionTypeRepository { get; set; }
        private QuestionRepository QuestionRepository { get; set; }
        private AnswerRepository AnswerRepository { get; set; }
        private QuestionAnswerRepository QuestionAnswerRepository { get; set; }
        private SurveyGeographyRepository SurveyGeographyRepository { get; set; }
        private HousingTypeRepository HousingTypeRepository { get; set; }
        private DistrictRepository DistrictRepository { get; set; }
        private InterviewerRepository InterviewerRepository { get; set; }
        private FormRepository FormRepository { get; set; }
        private FamilyRepository FamilyRepository { get; set; }
        private DataRepository DataRepository { get; set; }

        public UnitOfWork()
        {
            _db = new QuestionnaireContext();
        }

        public UnitOfWork(string connectionString)
        {
            _db = new QuestionnaireContext(connectionString);
        }

        public QuestionTypeRepository QuestionTypes
        {
            get
            {
                if (QuestionTypeRepository == null)
                    QuestionTypeRepository = new QuestionTypeRepository(_db);
                return QuestionTypeRepository;
            }
        }

        public QuestionRepository Questions
        {
            get
            {
                if (QuestionRepository == null)
                    QuestionRepository = new QuestionRepository(_db);
                return QuestionRepository;
            }
        }

        public AnswerRepository Answers
        {
            get
            {
                if (AnswerRepository == null)
                    AnswerRepository = new AnswerRepository(_db);
                return AnswerRepository;
            }
        }

        public QuestionAnswerRepository QuestionAnswers
        {
            get
            {
                if (QuestionAnswerRepository == null)
                    QuestionAnswerRepository = new QuestionAnswerRepository(_db);
                return QuestionAnswerRepository;
            }
        }

        public SurveyGeographyRepository SurveyGeographies
        {
            get
            {
                if (SurveyGeographyRepository == null)
                    SurveyGeographyRepository = new SurveyGeographyRepository(_db);
                return SurveyGeographyRepository;
            }
        }

        public HousingTypeRepository HousingTypes
        {
            get
            {
                if (HousingTypeRepository == null)
                    HousingTypeRepository = new HousingTypeRepository(_db);
                return HousingTypeRepository;
            }
        }

        public DistrictRepository Districts
        {
            get
            {
                if (DistrictRepository == null)
                    DistrictRepository = new DistrictRepository(_db);
                return DistrictRepository;
            }
        }

        public InterviewerRepository Interviewers
        {
            get
            {
                if (InterviewerRepository == null)
                    InterviewerRepository = new InterviewerRepository(_db);
                return InterviewerRepository;
            }
        }

        public FormRepository Forms
        {
            get
            {
                if (FormRepository == null)
                    FormRepository = new FormRepository(_db);
                return FormRepository;
            }
        }

        public FamilyRepository Families
        {
            get
            {
                if (FamilyRepository == null)
                    FamilyRepository = new FamilyRepository(_db);
                return FamilyRepository;
            }
        }

        public DataRepository Datas
        {
            get
            {
                if (DataRepository == null)
                    DataRepository = new DataRepository(_db);
                return DataRepository;
            }
        }

        public void Save()
        {
            _db.Save();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.DbDispose();
                }
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