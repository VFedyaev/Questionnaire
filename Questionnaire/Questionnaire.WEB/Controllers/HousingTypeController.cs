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
    public class HousingTypeController : Controller
    {
        private const int _itemsPerPage = 10;
        private IHousingTypeService HousingTypeService;

        public HousingTypeController(IHousingTypeService housingTypeService)
        {
            HousingTypeService = housingTypeService;
        }

        [Authorize(Roles = "admin, manager, user")]
        public ActionResult AjaxHousingTypeList(int? page)
        {
            IEnumerable<HousingTypeDTO> housingTypeDTOs = HousingTypeService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<HousingTypeVM> housingTypeVMs = Mapper.Map<IEnumerable<HousingTypeVM>>(housingTypeDTOs);

            return PartialView(housingTypeVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: HousingType
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Index(int? page)
        {
            IEnumerable<HousingTypeDTO> housingTypeDTOs = HousingTypeService
               .GetListOrderedByName()
               .ToList();
            IEnumerable<HousingTypeVM> housingTypeVMs = Mapper.Map<IEnumerable<HousingTypeVM>>(housingTypeDTOs);

            return PartialView(housingTypeVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: HousingType/Details/5
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Details(int? id)
        {
            try
            {
                HousingTypeDTO housingTypeDTO = HousingTypeService.Get(id);
                HousingTypeVM housingTypeVMs = Mapper.Map<HousingTypeVM>(housingTypeDTO);

                return View(housingTypeVMs);
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

        // GET: HousingType/Create
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HousingType/Create
        [Authorize(Roles = "admin, manager, user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] HousingTypeVM housingTypeVM)
        {
            if (ModelState.IsValid)
            {
                HousingTypeDTO housingTypeDTO = Mapper.Map<HousingTypeDTO>(housingTypeVM);
                HousingTypeService.Add(housingTypeDTO);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: HousingType/Edit/5
        [Authorize(Roles = "admin, manager")]
        public ActionResult Edit(int? id)
        {
            try
            {
                HousingTypeDTO housingTypeDTO = HousingTypeService.Get(id);
                HousingTypeVM housingTypeVM = Mapper.Map<HousingTypeVM>(housingTypeDTO);
                return View(housingTypeVM);
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

        // POST: HousingType/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] HousingTypeVM housingTypeVM)
        {
            if (ModelState.IsValid)
            {
                HousingTypeDTO housingTypeDTO = Mapper.Map<HousingTypeDTO>(housingTypeVM);
                HousingTypeService.Update(housingTypeDTO);
                return RedirectToAction("Index");
            }
            return View(housingTypeVM);
        }

        // GET: HousingType/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                HousingTypeService.Delete(id);
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