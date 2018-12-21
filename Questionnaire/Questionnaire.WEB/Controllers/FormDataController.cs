using AutoMapper;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Interfaces;
using Questionnaire.WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Questionnaire.WEB.Controllers
{
    public class FormDataController : Controller
    {
        private IQuestionAnswerService QuestionAnswerService;
        private IQuestionTypeService QuestionTypeService;

        public FormDataController(IQuestionAnswerService questionAnswerService, IQuestionTypeService questionTypeService)
        {
            QuestionAnswerService = questionAnswerService;
            QuestionTypeService = questionTypeService;
        }

        // GET: FormDataControlelr
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuestionAnswers(int questionTypeId)
        {
            try
            {
                ViewBag.Sections = Mapper.Map<IEnumerable<QuestionTypeVM>>(QuestionTypeService.GetAll().ToList());
                ViewBag.Section = QuestionTypeService.Get(questionTypeId).Name;
                var formDataDTOs = QuestionAnswerService.GetQuestionAnswersByQuestionType(questionTypeId).ToList();
                var formDataVMs = Mapper.Map<IEnumerable<FormDataVM>>(formDataDTOs);
                //IEnumerable<AnswerVM> answerVMs = Mapper.Map<IEnumerable<AnswerVM>>(answerDTOs);

                return View(formDataVMs);
            }
            catch (ArgumentNullException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}