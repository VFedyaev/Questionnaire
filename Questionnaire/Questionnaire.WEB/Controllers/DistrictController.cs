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
    public class DistrictController : Controller
    {
        private const int _itemsPerPage = 10;
        private IDistrictService DistrictService;

        public DistrictController(IDistrictService districtService)
        {
            DistrictService = districtService;
        }

        [Authorize(Roles = "admin, manager, user")]
        public ActionResult AjaxDistrictList(int? page)
        {
            IEnumerable<DistrictDTO> districtDTOs = DistrictService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<DistrictVM> districtVMs = Mapper.Map<IEnumerable<DistrictVM>>(districtDTOs);

            return PartialView(districtVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: District
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Index(int? page)
        {

            IEnumerable<DistrictDTO> districtDTOs = DistrictService
               .GetListOrderedByName()
               .ToList();
            IEnumerable<DistrictVM> districtVMs = Mapper.Map<IEnumerable<DistrictVM>>(districtDTOs);

            return View(districtVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: District/Details/5
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Details(int? id)
        {
            try
            {
                DistrictDTO districtDTO = DistrictService.Get(id);
                DistrictVM districtVMs = Mapper.Map<DistrictVM>(districtDTO);

                return View(districtVMs);
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

        // GET: District/Create
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: District/Create
        [HttpPost]
        [Authorize(Roles = "admin, manager, user")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] DistrictVM districtVM)
        {
            if (ModelState.IsValid)
            {
                DistrictDTO districtDTO = Mapper.Map<DistrictDTO>(districtVM);
                DistrictService.Add(districtDTO);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: District/Edit/5
        [Authorize(Roles = "admin, manager")]
        public ActionResult Edit(int? id)
        {
            try
            {
                DistrictDTO districtDTO = DistrictService.Get(id);
                DistrictVM districtVM = Mapper.Map<DistrictVM>(districtDTO);
                return View(districtVM);
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

        // POST: District/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DistrictVM districtVM)
        {
            if (ModelState.IsValid)
            {
                DistrictDTO districtDTO = Mapper.Map<DistrictDTO>(districtVM);
                DistrictService.Update(districtDTO);
                return RedirectToAction("Index");
            }
            return View(districtVM);
        }

        // GET: District/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                DistrictService.Delete(id);
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