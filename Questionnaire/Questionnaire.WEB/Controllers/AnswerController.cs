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
    public class AnswerController : Controller
    {
        private const int _itemsPerPage = 10;
        private IAnswerService AnswerService;

        public AnswerController(IAnswerService answerService)
        {
            AnswerService = answerService;
        }

        public ActionResult AjaxAnswerList(int? page)
        {
            IEnumerable<AnswerDTO> answerDTOs = AnswerService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<AnswerVM> answerVMs = Mapper.Map<IEnumerable<AnswerVM>>(answerDTOs);

            return PartialView(answerVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: Answer
        public ActionResult Index(int? page)
        {

            IEnumerable<AnswerDTO> answerDTOs = AnswerService
               .GetListOrderedByName()
               .ToList();
            IEnumerable<AnswerVM> answerVMs = Mapper.Map<IEnumerable<AnswerVM>>(answerDTOs);

            return View(answerVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: Answer/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                AnswerDTO answerDTO = AnswerService.Get(id);
                AnswerVM answerVMs = Mapper.Map<AnswerVM>(answerDTO);

                return View(answerVMs);
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

        // GET: Answer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Answer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] AnswerVM answerVM)
        {
            if (ModelState.IsValid)
            {
                AnswerDTO answerDTO = Mapper.Map<AnswerDTO>(answerVM);
                AnswerService.Add(answerDTO);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                AnswerDTO answerDTO = AnswerService.Get(id);
                AnswerVM answerVM = Mapper.Map<AnswerVM>(answerDTO);
                return View(answerVM);
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

        // POST: Answer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AnswerVM answerVM)
        {
            if (ModelState.IsValid)
            {
                AnswerDTO answerDTO = Mapper.Map<AnswerDTO>(answerVM);
                AnswerService.Update(answerDTO);
                return RedirectToAction("Index");
            }
            return View(answerVM);
        }

        // GET: Answer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                AnswerService.Delete(id);
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