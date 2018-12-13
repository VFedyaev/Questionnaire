using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Infrastructure.Exceptions;
using Questionnaire.BLL.Interfaces;
using Questionnaire.DAL.Entities;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public class InterviewerService : IInterviewerService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public InterviewerService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public InterviewerDTO Get(int id)
        {
            Interviewer interviewer = _unitOfWork.Interviewers.Get(id);

            return Mapper.Map<InterviewerDTO>(interviewer);
        }

        public InterviewerDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            Interviewer interviewer = _unitOfWork.Interviewers.Get(id);
            if (interviewer == null)
                throw new NotFoundException();

            return Mapper.Map<InterviewerDTO>(interviewer);
        }

        public IEnumerable<InterviewerDTO> GetAll()
        {
            List<Interviewer> interviewers = _unitOfWork.Interviewers.GetAll().ToList();

            return Mapper.Map<IEnumerable<InterviewerDTO>>(interviewers);
        }

        public IEnumerable<InterviewerDTO> GetListOrderedByName()
        {
            List<Interviewer> interviewers = _unitOfWork.Interviewers.GetAll().OrderBy(n => n.Name).ToList();

            return Mapper.Map<IEnumerable<InterviewerDTO>>(interviewers);
        }

        public void Add(InterviewerDTO interviewerDTO)
        {
            Interviewer interviewer = Mapper.Map<Interviewer>(interviewerDTO);
            _unitOfWork.Interviewers.Create(interviewer);
            _unitOfWork.Save();
        }

        public void Update(InterviewerDTO interviewerDTO)
        {
            Interviewer interviewer = Mapper.Map<Interviewer>(interviewerDTO);

            _unitOfWork.Interviewers.Update(interviewer);
            _unitOfWork.Save();
        }


        public void Delete(int id)
        {
            if (HasRelations(id))
                throw new HasRelationsException();

            Interviewer interviewer = _unitOfWork.Interviewers.Get(id);
            if (interviewer == null)
                throw new NotFoundException();

            _unitOfWork.Interviewers.Delete(id);
            _unitOfWork.Save();
        }

        public bool HasRelations(int id)
        {
            var relations = _unitOfWork.Forms.Find(h => h.InterviewerId == id);

            return relations.Count() > 0;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
