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
    public class SurveyGeographyController : Controller
    {

        private const int _itemsPerPage = 10;
        private ISurveyGeographyService SurveyGeographyService;

        public SurveyGeographyController(ISurveyGeographyService surveyGeographyService)
        {
            SurveyGeographyService = surveyGeographyService;
        }

        [Authorize(Roles = "admin, manager")]
        public ActionResult AjaxSurveyGeographyList(int? page)
        {
            IEnumerable<SurveyGeographyDTO> surveyGeographyDTOs = SurveyGeographyService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<SurveyGeographyVM> surveyGeographyVMs = Mapper.Map<IEnumerable<SurveyGeographyVM>>(surveyGeographyDTOs);

            return PartialView(surveyGeographyVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: SurveyGeography
        [Authorize(Roles = "admin, manager")]
        public ActionResult Index(int? page)
        {

            IEnumerable<SurveyGeographyDTO> surveyGeographyDTOs = SurveyGeographyService
               .GetListOrderedByName()
               .ToList();
            IEnumerable<SurveyGeographyVM> surveyGeographyVMs = Mapper.Map<IEnumerable<SurveyGeographyVM>>(surveyGeographyDTOs);

            return View(surveyGeographyVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: SurveyGeography/Details/5
        [Authorize(Roles = "admin, manager")]
        public ActionResult Details(int? id)
        {
            try
            {
                SurveyGeographyDTO surveyGeographyDTO = SurveyGeographyService.Get(id);
                SurveyGeographyVM surveyGeographyVMs = Mapper.Map<SurveyGeographyVM>(surveyGeographyDTO);

                return View(surveyGeographyVMs);
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

        // GET: SurveyGeography/Create
        [Authorize(Roles = "admin, manager")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyGeography/Create
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] SurveyGeographyVM surveyGeographyVM)
        {
            if (ModelState.IsValid)
            {
                SurveyGeographyDTO surveyGeographyDTO = Mapper.Map<SurveyGeographyDTO>(surveyGeographyVM);
                SurveyGeographyService.Add(surveyGeographyDTO);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: SurveyGeography/Edit/5
        [Authorize(Roles = "admin, manager")]
        public ActionResult Edit(int? id)
        {
            try
            {
                SurveyGeographyDTO surveyGeographyDTO = SurveyGeographyService.Get(id);
                SurveyGeographyVM surveyGeographyVM = Mapper.Map<SurveyGeographyVM>(surveyGeographyDTO);
                return View(surveyGeographyVM);
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

        // POST: SurveyGeography/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SurveyGeographyVM surveyGeographyVM)
        {
            if (ModelState.IsValid)
            {
                SurveyGeographyDTO surveyGeographyDTO = Mapper.Map<SurveyGeographyDTO>(surveyGeographyVM);
                SurveyGeographyService.Update(surveyGeographyDTO);
                return RedirectToAction("Index");
            }
            return View(surveyGeographyVM);
        }

        // GET: SurveyGeography/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                SurveyGeographyService.Delete(id);
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