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
                //case "equipmentType":
                //    result = GetEquipmentTypeFilteredListAndView(words);
                //    break;
                //case "component":
                //    result = GetComponentFilteredListAndView(words);
                //    break;
                //case "componentType":
                //    result = GetComponentTypeFilteredListAndVew(words);
                //    break;
                //case "statusType":
                //    result = GetStatusTypeFilteredListAndView(words);
                //    break;
                //case "repairPlace":
                //    result = GetRepairPlaceFilteredListAndView(words);
                //    break;
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

        //private ModelAndViewDTO GetEquipmentTypeFilteredListAndView(string[] words)
        //{
        //    var equipmentTypeList = _unitOfWork.EquipmentTypes.GetAll().Where(t => words.All(t.Name.ToLower().Contains)).ToList();

        //    return new ModelAndViewDTO
        //    {
        //        Model = Mapper.Map<IEnumerable<EquipmentTypeDTO>>(equipmentTypeList),
        //        View = "EquipmentTypes"
        //    };
        //}

        //private ModelAndViewDTO GetComponentFilteredListAndView(string[] words)
        //{
        //    var componentList = _unitOfWork.Components.GetAll().Where(c => c.InventNumber != null && words.All(c.InventNumber.ToLower().Contains)).ToList();

        //    return new ModelAndViewDTO
        //    {
        //        Model = Mapper.Map<IEnumerable<ComponentDTO>>(componentList),
        //        View = "Components"
        //    };
        //}

        //private ModelAndViewDTO GetComponentTypeFilteredListAndVew(string[] words)
        //{
        //    var componentTypeList = _unitOfWork.ComponentTypes.GetAll().Where(t => words.All(t.Name.ToLower().Contains)).ToList();

        //    return new ModelAndViewDTO
        //    {
        //        Model = Mapper.Map<IEnumerable<ComponentTypeDTO>>(componentTypeList),
        //        View = "ComponentTypes"
        //    };
        //}

        //private ModelAndViewDTO GetStatusTypeFilteredListAndView(string[] words)
        //{
        //    var statusTypeList = _unitOfWork.StatusTypes.GetAll().Where(st => words.All(st.Name.ToLower().Contains)).ToList();

        //    return new ModelAndViewDTO
        //    {
        //        Model = Mapper.Map<IEnumerable<StatusTypeDTO>>(statusTypeList),
        //        View = "StatusTypes"
        //    };
        //}

        //private ModelAndViewDTO GetRepairPlaceFilteredListAndView(string[] words)
        //{
        //    var repairPlaceList = _unitOfWork.RepairPlaces.GetAll().Where(rp => words.All(rp.Name.ToLower().Contains)).ToList();

        //    return new ModelAndViewDTO
        //    {
        //        Model = Mapper.Map<IEnumerable<RepairPlaceDTO>>(repairPlaceList),
        //        View = "RepairPlaces"
        //    };
        //}
    }
}
