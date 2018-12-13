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

namespace Questionnaire.WEB.Controllers.Questionnaire
{
    public class QuestionTypeController : Controller
    {
        private const int _itemsPerPage = 10;
        private IQuestionTypeService QuestionTypeService;

        public QuestionTypeController(IQuestionTypeService questionTypeService)
        {
            QuestionTypeService = questionTypeService;
        }

        public ActionResult AjaxQuestionTypeList(int? page)
        {
            IEnumerable<QuestionTypeDTO> questionTypeDTOs = QuestionTypeService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<QuestionTypeVM> questionTypeVMs = Mapper.Map<IEnumerable<QuestionTypeVM>>(questionTypeDTOs);

            return PartialView(questionTypeVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }
        // GET: QuestionType
        public ActionResult Index(int? page)
        {

            IEnumerable<QuestionTypeDTO> questionTypeDTOs = QuestionTypeService
               .GetListOrderedByName()
               .ToList();
            IEnumerable<QuestionTypeVM> questionTypeVMs = Mapper.Map<IEnumerable<QuestionTypeVM>>(questionTypeDTOs);

            return View(questionTypeVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: QuestionType/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                QuestionTypeDTO questionTypeDTO = QuestionTypeService.Get(id);
                QuestionTypeVM questionTypeVM = Mapper.Map<QuestionTypeVM>(questionTypeDTO);

                return View(questionTypeVM);
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

        // GET: QuestionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] QuestionTypeVM questionTypeVM)
        {
            if (ModelState.IsValid)
            {
                QuestionTypeDTO questionTypeDTO = Mapper.Map<QuestionTypeDTO>(questionTypeVM);
                QuestionTypeService.Add(questionTypeDTO);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: QuestionType/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                QuestionTypeDTO questionTypeDTO = QuestionTypeService.Get(id);
                QuestionTypeVM questionTypeVM = Mapper.Map<QuestionTypeVM>(questionTypeDTO);
                return View(questionTypeVM);
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

        // POST: QuestionType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] QuestionTypeVM questionTypeVM)
        {
            if (ModelState.IsValid)
            {
                QuestionTypeDTO questionTypeDTO = Mapper.Map<QuestionTypeDTO>(questionTypeVM);
                QuestionTypeService.Update(questionTypeDTO);
                return RedirectToAction("Index");
            }
            return View(questionTypeVM);
        }

        // GET: QuestionType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                QuestionTypeService.Delete(id);
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
