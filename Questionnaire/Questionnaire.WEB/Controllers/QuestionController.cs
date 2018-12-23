using AutoMapper;
using PagedList;
using Questionnaire.BLL.DTO;
using Questionnaire.BLL.Infrastructure.Exceptions;
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
    public class QuestionController : Controller
    {
        private const int _itemsPerPage = 10;
        private IQuestionTypeService QuestionTypeService;
        private IQuestionService QuestionService;

        public QuestionController(IQuestionTypeService questionTypeService,IQuestionService questionService)
        {
            QuestionTypeService = questionTypeService;
            QuestionService = questionService;
        }

        [Authorize(Roles = "admin, manager, user")]
        public ActionResult AjaxQuestionTypeList(int? page)
        {
            IEnumerable<QuestionDTO> questionDTOs = QuestionService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<QuestionVM> questionVMs = Mapper.Map<IEnumerable<QuestionVM>>(questionDTOs);

            return PartialView(questionVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }
        // GET: Question
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Index(int? page)
        {
            IEnumerable<QuestionDTO> questionDTOs = QuestionService
               .GetListOrderedByName()
               .ToList();
            IEnumerable<QuestionVM> questionVMs = Mapper.Map<IEnumerable<QuestionVM>>(questionDTOs);

            return View(questionVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: Question/Details/5
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Details(int? id)
        {
            try
            {
                QuestionDTO questionDTO = QuestionService.Get(id);
                QuestionVM questionVM = Mapper.Map<QuestionVM>(questionDTO);

                return View(questionVM);
            }
            catch (ArgumentException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch (NotFoundException)
            {
                return HttpNotFound();
            }
        }

        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Create()
        {
            ViewBag.QuestionTypeId = GetQuestionTypeIdSelectList();

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager, user")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionTypeId,Name,MultipleAnswer")] QuestionVM questionVM)
        {
            if (ModelState.IsValid)
            {
                QuestionDTO questionDTO = Mapper.Map<QuestionDTO>(questionVM);
                //int questionId = QuestionService.AddAndGetId(questionDTO);
                QuestionService.Add(questionDTO);
                return RedirectToAction("Index");
            }

            ViewBag.QuestionTypeId = GetQuestionTypeIdSelectList(questionVM.QuestionTypeId);

            return View(questionVM);
        }

        // GET: Question/Edit/5
        [Authorize(Roles = "admin, manager")]
        public ActionResult Edit(int? id)
        {
            try
            {
                QuestionDTO questionDTO = QuestionService.Get(id);
                QuestionVM questionVM = Mapper.Map<QuestionVM>(questionDTO);

                ViewBag.QuestionTypeId = GetQuestionTypeIdSelectList(questionVM.QuestionTypeId);

                return View(questionVM);
            }
            catch (ArgumentNullException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            catch (NotFoundException)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuestionTypeId,Name,MultipleAnswer")] QuestionVM questionVM)
        {
            if (ModelState.IsValid)
            {
                QuestionDTO questionDTO = Mapper.Map<QuestionDTO>(questionVM);
                QuestionService.Update(questionDTO);
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError(null, "Что-то пошло не так. Не удалось сохранить изменения.");

            ViewBag.QuestionTypeId = GetQuestionTypeIdSelectList(questionVM.QuestionTypeId);

            return View(questionVM);
        }

        public SelectList GetQuestionTypeIdSelectList(short? selectedValue = null)
        {
            return new SelectList(QuestionTypeService.GetAll().ToList(), "Id", "Name", selectedValue);
        }

        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Answers(int? questionId)
        {
            try
            {
                IEnumerable<AnswerDTO> answerDTOs = QuestionService.GetAnswers(questionId).ToList();
                IEnumerable<AnswerVM> answerVMs = Mapper.Map<IEnumerable<AnswerVM>>(answerDTOs);

                ViewBag.QuestionId = questionId;

                return View(answerVMs);
            }
            catch (ArgumentNullException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Question/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                QuestionService.Delete(id);
            }
            catch (NotFoundException)
            {
                return HttpNotFound();
            }
            catch (HasRelationsException)
            {
                return Content("Удаление невозможно.");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}