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

        public ActionResult AjaxQuestionTypeList(int? page)
        {
            IEnumerable<QuestionDTO> questionDTOs = QuestionService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<QuestionVM> questionVMs = Mapper.Map<IEnumerable<QuestionVM>>(questionDTOs);

            return PartialView(questionVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }
        // GET: QuestionType
        public ActionResult Index(int? page)
        {
            IEnumerable<QuestionDTO> questionDTOs = QuestionService
               .GetListOrderedByName()
               .ToList();
            IEnumerable<QuestionVM> questionVMs = Mapper.Map<IEnumerable<QuestionVM>>(questionDTOs);

            return View(questionVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: QuestionType/Details/5
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

        public ActionResult Create()
        {
            ViewBag.QuestionTypeId = GetQuestionTypeIdSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionTypeId,Name")] QuestionVM questionVM)
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

        // GET: QuestionType/Edit/5
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuestionTypeId,Name")] QuestionVM questionVM)
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

        // GET: QuestionType/Delete/5
        [HttpPost]
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