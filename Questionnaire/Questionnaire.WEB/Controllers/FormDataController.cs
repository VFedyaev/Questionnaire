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
        private IDataService DataService;
        private IFormService FormService;

        public FormDataController(IQuestionAnswerService questionAnswerService, IQuestionTypeService questionTypeService, IDataService dataService, IFormService formService)
        {
            QuestionAnswerService = questionAnswerService;
            QuestionTypeService = questionTypeService;
            DataService = dataService;
            FormService = formService;
        }

        // GET: FormDataControlelr
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuestionAnswers(int id, int questionTypeId)
        {
            try
            {
                ViewBag.FormId = id; 
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool SaveForm(string formId, string[] options, string[][] optionsWithComment)
        {
            int FormId = int.Parse(formId);
            if (options != null && options.Length > 0)
            {
                foreach (var option in options)
                {
                    DataService.Add(new DataDTO
                    {
                        QuestionAnswerId = int.Parse(option),
                        FormId = FormId
                    });
                }
            }

            if (optionsWithComment != null && optionsWithComment.Length > 0)
            {
                foreach (var optionWithComment in optionsWithComment)
                {
                    DataService.Add(new DataDTO
                    {
                        QuestionAnswerId = int.Parse(optionWithComment[0]),
                        FormId = FormId,
                        Comment = optionWithComment[1]
                    });
                }
            }

            return true;
        }
    }
}