using Questionnaire.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Questionnaire.WEB.Controllers
{
    public class RelationController : Controller
    {
        IQuestionAnswerService QuestionAnswerService;

        public RelationController(IQuestionAnswerService questionAnswerService)
        {
            QuestionAnswerService = questionAnswerService;
        }

        [HttpPost]
        //[Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAnswers(int? questionId)
        {
            string[] answerIds = Request.Form.GetValues("answerId[]") ?? new string[0];
            try
            {
                QuestionAnswerService.UpdateQuestionRelations(questionId, answerIds);
            }
            catch (ArgumentNullException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch
            {
                QuestionAnswerService.DeleteRelationsByQuestionId((int)questionId);
            }

            return RedirectToRoute(new
            {
                controller = "Question",
                action = "Answers",
                questionId
            });
        }
    }
}