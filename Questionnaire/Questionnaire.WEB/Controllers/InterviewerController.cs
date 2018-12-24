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
    public class InterviewerController : Controller
    {
        private const int _itemsPerPage = 10;
        private IInterviewerService InterviewerService;

        public InterviewerController(IInterviewerService interviewerService)
        {
            InterviewerService = interviewerService;
        }

        [Authorize(Roles = "admin, manager")]
        public ActionResult AjaxInterviewerList(int? page)
        {
            IEnumerable<InterviewerDTO> interviewerDTOs = InterviewerService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<InterviewerVM> interviewerVMs = Mapper.Map<IEnumerable<InterviewerVM>>(interviewerDTOs);

            return PartialView(interviewerVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: Interviewer
        [Authorize(Roles = "admin, manager")]
        public ActionResult Index(int? page)
        {

            IEnumerable<InterviewerDTO> interviewerDTOs = InterviewerService
               .GetListOrderedByName()
               .ToList();
            IEnumerable<InterviewerVM> interviewerVMs = Mapper.Map<IEnumerable<InterviewerVM>>(interviewerDTOs);

            return View(interviewerVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: Interviewer/Details/5
        [Authorize(Roles = "admin, manager")]
        public ActionResult Details(int? id)
        {
            try
            {
                InterviewerDTO interviewerDTO = InterviewerService.Get(id);
                InterviewerVM interviewerVMs = Mapper.Map<InterviewerVM>(interviewerDTO);

                return View(interviewerVMs);
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

        // GET: Interviewer/Create
        [Authorize(Roles = "admin, manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interviewer/Create
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Phone")] InterviewerVM interviewerVM)
        {
            if (ModelState.IsValid)
            {
                InterviewerDTO interviewerDTO = Mapper.Map<InterviewerDTO>(interviewerVM);
                InterviewerService.Add(interviewerDTO);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Interviewer/Edit/5
        [Authorize(Roles = "admin, manager")]
        public ActionResult Edit(int? id)
        {
            try
            {
                InterviewerDTO interviewerDTO = InterviewerService.Get(id);
                InterviewerVM interviewerVM = Mapper.Map<InterviewerVM>(interviewerDTO);
                return View(interviewerVM);
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

        // POST: Interviewer/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone")] InterviewerVM interviewerVM)
        {
            if (ModelState.IsValid)
            {
                InterviewerDTO interviewerDTO = Mapper.Map<InterviewerDTO>(interviewerVM);
                InterviewerService.Update(interviewerDTO);
                return RedirectToAction("Index");
            }
            return View(interviewerVM);
        }

        // GET: Interviewer/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                InterviewerService.Delete(id);
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