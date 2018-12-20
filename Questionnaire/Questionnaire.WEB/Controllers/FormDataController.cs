using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Interfaces;
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

        public FormDataController(IQuestionAnswerService questionAnswerService)
        {
            QuestionAnswerService = questionAnswerService;
        }

        // GET: FormDataControlelr
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuestionAnswers()
        {
            try
            {
                IEnumerable<FormDataDTO> formDataDTOs = QuestionAnswerService.GetQuestionAnswersByQuestionType().ToList();
                //IEnumerable<AnswerVM> answerVMs = Mapper.Map<IEnumerable<AnswerVM>>(answerDTOs);


                return View(formDataDTOs);
            }
            catch (ArgumentNullException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}