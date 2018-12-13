﻿using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Interfaces;
using Questionnaire.WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Questionnaire.WEB.Controllers
{
    public class SearchController : Controller
    {
        ISearchService SearchService;
        public SearchController(ISearchService searchService)
        {
            SearchService = searchService;
        }

        //[Authorize(Roles = "admin, manager, user")]
        public ActionResult AdminSearch(string title, string type)
        {
            ModelAndViewDTO result = SearchService.GetFilteredModelAndView(title, type);

            if (result.Model.Count() > 0)
            {
                string modelType = result.Model.First().GetType().ToString().Split('.').Last();
                switch (modelType)
                {
                    case "QuestionTypeDTO":
                        result.Model = Mapper.Map<IEnumerable<QuestionTypeVM>>(result.Model);
                        break;
                    //case "EquipmentTypeDTO":
                    //    result.Model = Mapper.Map<IEnumerable<EquipmentTypeVM>>(result.Model);
                    //    break;
                    //case "ComponentDTO":
                    //    result.Model = Mapper.Map<IEnumerable<ComponentVM>>(result.Model);
                    //    break;
                    //case "ComponentTypeDTO":
                    //    result.Model = Mapper.Map<IEnumerable<ComponentTypeVM>>(result.Model);
                    //    break;
                    //case "StatusTypeDTO":
                    //    result.Model = Mapper.Map<IEnumerable<StatusTypeVM>>(result.Model);
                    //    break;
                    //case "RepairPlaceDTO":
                    //    result.Model = Mapper.Map<IEnumerable<RepairPlaceVM>>(result.Model);
                    //    break;
                }
            }
            else
                result.View = "NotFound";

            return PartialView(result.View, result.Model);
        }

        public ActionResult NotFoundResult()
        {
            return PartialView("~/Views/Error/NotFoundError.cshtml");
        }
    }
}