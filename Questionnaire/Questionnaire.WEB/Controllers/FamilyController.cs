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
    public class FamilyController : Controller
    {
        private const int _itemsPerPage = 10;
        private IFamilyService FamilyService;
        private IFormService FormService;

        public FamilyController(IFamilyService familyService, IFormService formService)
        {
            FamilyService = familyService;
            FormService = formService;
        }

        public ActionResult AjaxFamilyList(int? page)
        {
            IEnumerable<FamilyDTO> familyDTOs = FamilyService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<FamilyVM> familyVMs = Mapper.Map<IEnumerable<FamilyVM>>(familyDTOs);

            return PartialView(familyVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }
        // GET: Family
        public ActionResult Index(int? page)
        {
            IEnumerable<FamilyDTO> familyDTOs = FamilyService
                 .GetListOrderedByName()
                 .ToList();
            IEnumerable<FamilyVM> familyVMs = Mapper.Map<IEnumerable<FamilyVM>>(familyDTOs);

            return PartialView(familyVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: Family/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                FamilyDTO familyDTO = FamilyService.Get(id);
                FamilyVM familyVM = Mapper.Map<FamilyVM>(familyDTO);

                return View(familyVM);
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
            ViewBag.FormId = GetFormIdSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Sex, DateBorn, Age, FormId")] FamilyVM familyVM)
        {
            if (ModelState.IsValid)
            {
                FamilyDTO familyDTO = Mapper.Map<FamilyDTO>(familyVM);
                //int questionId = QuestionService.AddAndGetId(questionDTO);
                FamilyService.Add(familyDTO);
                return RedirectToAction("Index");
            }
            ViewBag.FormId = GetFormIdSelectList(familyVM.FormId);

            return View(familyVM);
        }

        // GET: Family/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                FamilyDTO familyDTO = FamilyService.Get(id);
                FamilyVM familyVM = Mapper.Map<FamilyVM>(familyDTO);

                ViewBag.FormId = GetFormIdSelectList(familyVM.FormId);

                return View(familyVM);
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
        public ActionResult Edit([Bind(Include = "Id, Name, Sex, DateBorn, Age, FormId")] FamilyVM familyVM)
        {
            if (ModelState.IsValid)
            {
                FamilyDTO familyDTO = Mapper.Map<FamilyDTO>(familyVM);
                FamilyService.Update(familyDTO);
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError(null, "Что-то пошло не так. Не удалось сохранить изменения.");

            ViewBag.FormId = GetFormIdSelectList(familyVM.FormId);

            return View(familyVM);
        }

        public SelectList GetFormIdSelectList(int? selectedValue = null)
        {
            return new SelectList(FormService.GetAll().ToList(), "Id", "NumberForm", selectedValue);
        }

        // GET: Family/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                FamilyService.Delete(id);
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