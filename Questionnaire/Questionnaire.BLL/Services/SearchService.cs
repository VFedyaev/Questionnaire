using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Interfaces;
using Questionnaire.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public class SearchService : ISearchService
    {
        private IUnitOfWork _unitOfWork { get; set; }
        public SearchService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public ModelAndViewDTO GetFilteredModelAndView(string inputTitle, string type)
        {
            ModelAndViewDTO result = new ModelAndViewDTO
            {
                Model = Enumerable.Empty<object>(),
                View = "NotFound"
            };
            string title = inputTitle.Trim();
            if (title.Length <= 0)
                return result;

            string[] words = title.ToLower().Split(' ');

            switch (type)
            {
                case "questionType":
                    result = GetQuestionTypeFilteredListAndView(words);
                    break;
                case "question":
                    result = GetQuestionFilteredListAndView(words);
                    break;
                case "answer":
                    result = GetAnswerFilteredListAndView(words);
                    break;
                //case "componentType":
                //    result = GetComponentTypeFilteredListAndVew(words);
                //    break;
                case "surveyGeography":
                    result = GetSurveyGeographyFilteredListAndView(words);
                    break;
                case "housingType":
                    result = GetHousingTypeFilteredListAndView(words);
                    break;
                case "district":
                    result = GetDistrictFilteredListAndView(words);
                    break;
                case "family":
                    result = GetFamilyFilteredListAndView(words);
                    break;
            }

            return result;
        }

        private ModelAndViewDTO GetQuestionTypeFilteredListAndView(string[] words)
        {
            var questionTypeList = _unitOfWork.QuestionTypes.GetAll().Where(e => words.All(e.Name.ToLower().Contains)).ToList();

            return new ModelAndViewDTO
            {
                Model = Mapper.Map<IEnumerable<QuestionTypeDTO>>(questionTypeList),
                View = "QuestionTypes"
            };
        }

        private ModelAndViewDTO GetQuestionFilteredListAndView(string[] words)
        {
            var questionList = _unitOfWork.Questions.GetAll().Where(t => words.All(t.Name.ToLower().Contains)).ToList();

            return new ModelAndViewDTO
            {
                Model = Mapper.Map<IEnumerable<QuestionDTO>>(questionList),
                View = "Questions"
            };
        }

        private ModelAndViewDTO GetAnswerFilteredListAndView(string[] words)
        {
            var answerList = _unitOfWork.Answers.GetAll().Where(t => words.All(t.Name.ToLower().Contains)).ToList();

            return new ModelAndViewDTO
            {
                Model = Mapper.Map<IEnumerable<AnswerDTO>>(answerList),
                View = "Answers"
            };
        }

        //private ModelAndViewDTO GetComponentTypeFilteredListAndVew(string[] words)
        //{
        //    var componentTypeList = _unitOfWork.ComponentTypes.GetAll().Where(t => words.All(t.Name.ToLower().Contains)).ToList();

        //    return new ModelAndViewDTO
        //    {
        //        Model = Mapper.Map<IEnumerable<ComponentTypeDTO>>(componentTypeList),
        //        View = "ComponentTypes"
        //    };
        //}

        private ModelAndViewDTO GetSurveyGeographyFilteredListAndView(string[] words)
        {
            var surveyGeographyList = _unitOfWork.SurveyGeographies.GetAll().Where(st => words.All(st.Name.ToLower().Contains)).ToList();

            return new ModelAndViewDTO
            {
                Model = Mapper.Map<IEnumerable<SurveyGeographyDTO>>(surveyGeographyList),
                View = "SurveyGeographies"
            };
        }

        private ModelAndViewDTO GetHousingTypeFilteredListAndView(string[] words)
        {
            var housingTypeList = _unitOfWork.HousingTypes.GetAll().Where(rp => words.All(rp.Name.ToLower().Contains)).ToList();

            return new ModelAndViewDTO
            {
                Model = Mapper.Map<IEnumerable<HousingTypeDTO>>(housingTypeList),
                View = "HousingTypes"
            };
        }

        private ModelAndViewDTO GetDistrictFilteredListAndView(string[] words)
        {
            var districtList = _unitOfWork.Districts.GetAll().Where(rp => words.All(rp.Name.ToLower().Contains)).ToList();

            return new ModelAndViewDTO
            {
                Model = Mapper.Map<IEnumerable<DistrictDTO>>(districtList),
                View = "Districs"
            };
        }
        private ModelAndViewDTO GetFamilyFilteredListAndView(string[] words)
        {
            var familyList = _unitOfWork.Families.GetAll().Where(rp => words.All(rp.Name.ToLower().Contains)).ToList();

            return new ModelAndViewDTO
            {
                Model = Mapper.Map<IEnumerable<FamilyDTO>>(familyList),
                View = "Families"
            };
        }
    }
}
