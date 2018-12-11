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
    public class SurveyGeographyService : ISurveyGeographyService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public SurveyGeographyService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public SurveyGeographyDTO Get(int id)
        {
            SurveyGeography surveyGeography = _unitOfWork.SurveyGeographies.Get(id);

            return Mapper.Map<SurveyGeographyDTO>(surveyGeography);
        }

        public SurveyGeographyDTO Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            SurveyGeography surveyGeography = _unitOfWork.SurveyGeographies.Get(id);
            if (surveyGeography == null)
                throw new NotFoundException();

            return Mapper.Map<SurveyGeographyDTO>(surveyGeography);
        }

        public IEnumerable<SurveyGeographyDTO> GetAll()
        {
            List<SurveyGeography> surveyGeographies = _unitOfWork.SurveyGeographies.GetAll().ToList();

            return Mapper.Map<IEnumerable<SurveyGeographyDTO>>(surveyGeographies);
        }

        public IEnumerable<SurveyGeographyDTO> GetListOrderedByName()
        {
            List<SurveyGeography> surveyGeographies = _unitOfWork.SurveyGeographies.GetAll().OrderBy(n => n.Name).ToList();

            return Mapper.Map<IEnumerable<SurveyGeographyDTO>>(surveyGeographies);
        }

        public void Add(SurveyGeographyDTO surveyGeographyDTO)
        {
            SurveyGeography surveyGeography = Mapper.Map<SurveyGeography>(surveyGeographyDTO);
            _unitOfWork.SurveyGeographies.Create(surveyGeography);
            _unitOfWork.Save();
        }

        public void Update(SurveyGeographyDTO surveyGeographyDTO)
        {
            SurveyGeography surveyGeography = Mapper.Map<SurveyGeography>(surveyGeographyDTO);

            _unitOfWork.SurveyGeographies.Update(surveyGeography);
            _unitOfWork.Save();
        }


        public void Delete(int id)
        {
            if (HasRelations(id))
                throw new HasRelationsException();

            _unitOfWork.SurveyGeographies.Delete(id);
            _unitOfWork.Save();
        }

        public bool HasRelations(int id)
        {
            var relations = _unitOfWork.Forms.Find(h => h.SurveyGeographyId == id);

            return relations.Count() > 0;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
