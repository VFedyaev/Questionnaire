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
    public class FormController : Controller
    {
        private const int _itemsPerPage = 10;
        private IFormService FormService;
        private ISurveyGeographyService SurveyGeographyService;
        private IHousingTypeService HousingTypeService;
        private IDistrictService DistrictService;
        private IInterviewerService InterviewerService;

        public FormController(IFormService formService,
            ISurveyGeographyService surveyGeographyService,
            IHousingTypeService housingTypeService,
            IDistrictService districtService,
            IInterviewerService interviewerService)
        {
            FormService = formService;
            SurveyGeographyService = surveyGeographyService;
            HousingTypeService = housingTypeService;
            DistrictService = districtService;
            InterviewerService = interviewerService;
        }

        public ActionResult AjaxFormList(int? page)
        {
            IEnumerable<FormDTO> formDTOs = FormService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<FormVM> formVMs = Mapper.Map<IEnumerable<FormVM>>(formDTOs);

            return PartialView(formVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }
        // GET: Form
        public ActionResult Index(int? page)
        {
            IEnumerable<FormDTO> formDTOs = FormService
                .GetListOrderedByName()
                .ToList();
            IEnumerable<FormVM> formVMs = Mapper.Map<IEnumerable<FormVM>>(formDTOs);

            return PartialView(formVMs.ToPagedList(page ?? 1, _itemsPerPage));
        }

        // GET: Form/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                FormDTO formDTO = FormService.Get(id);
                FormVM formVM = Mapper.Map<FormVM>(formDTO);

                return View(formVM);
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
            ViewBag.SurveyGeographyId = GetSurveyGeographySelectList();
            ViewBag.HousingTypeId = GetHousingTypeSelectList();
            ViewBag.DistrictId = GetDistrictSelectList();
            ViewBag.InterviewerId = GetInterviewerSelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumberForm, SurveyGeographyId, HousingTypeId, DistrictId, InterviewerId, Address, Phone,InterviewDate, StartTime, EndTime")] FormVM formVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FormDTO formDTO = Mapper.Map<FormDTO>(formVM);
                    //int questionId = QuestionService.AddAndGetId(questionDTO);
                    FormService.Add(formDTO);
                    return RedirectToAction("Index");
                }
                ViewBag.SurveyGeographyId = GetSurveyGeographySelectList(formVM.SurveyGeographyId);
                ViewBag.HousingTypeId = GetHousingTypeSelectList(formVM.HousingTypeId);
                ViewBag.DistrictId = GetDistrictSelectList(formVM.DistrictId);
                ViewBag.InterviewerId = GetInterviewerSelectList(formVM.InterviewerId);

                return View(formVM);
            }
            catch (UniqueConstraintException ex)
            {
                return Json(new { hasError = true, data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Form/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                FormDTO formDTO = FormService.Get(id);
                FormVM formVM = Mapper.Map<FormVM>(formDTO);

                ViewBag.SurveyGeographyId = GetSurveyGeographySelectList(formVM.SurveyGeographyId);
                ViewBag.HousingTypeId = GetHousingTypeSelectList(formVM.HousingTypeId);
                ViewBag.DistrictId = GetDistrictSelectList(formVM.DistrictId);
                ViewBag.InterviewerId = GetInterviewerSelectList(formVM.InterviewerId);

                return View(formVM);
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
        public ActionResult Edit([Bind(Include = "Id, NumberForm, SurveyGeographyId, HousingTypeId, DistrictId, InterviewerId, Address, Phone,InterviewDate, StartTime, EndTime")] FormVM formVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FormDTO formDTO = Mapper.Map<FormDTO>(formVM);
                    FormService.Update(formDTO);
                    return RedirectToAction("Index");
                }
                else
                    ModelState.AddModelError(null, "Что-то пошло не так. Не удалось сохранить изменения.");

                ViewBag.SurveyGeographyId = GetSurveyGeographySelectList(formVM.SurveyGeographyId);
                ViewBag.HousingTypeId = GetHousingTypeSelectList(formVM.HousingTypeId);
                ViewBag.DistrictId = GetDistrictSelectList(formVM.DistrictId);
                ViewBag.InterviewerId = GetInterviewerSelectList(formVM.InterviewerId);

                return View(formVM);
            }
            catch (UniqueConstraintException ex)
            {
                return Json(new {hasError = true, data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
    
        }

        public SelectList GetSurveyGeographySelectList(short? selectedValue = null)
        {
            return new SelectList(SurveyGeographyService.GetAll().ToList(), "Id", "Name", selectedValue);
        }

        public SelectList GetHousingTypeSelectList(short? selectedValue = null)
        {
            return new SelectList(HousingTypeService.GetAll().ToList(), "Id", "Name", selectedValue);
        }

        public SelectList GetDistrictSelectList(short? selectedValue = null)
        {
            return new SelectList(DistrictService.GetAll().ToList(), "Id", "Name", selectedValue);
        }

        public SelectList GetInterviewerSelectList(short? selectedValue = null)
        {
            return new SelectList(InterviewerService.GetAll().ToList(), "Id", "Name", selectedValue);
        }

        // GET: Form/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                FormService.Delete(id);
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