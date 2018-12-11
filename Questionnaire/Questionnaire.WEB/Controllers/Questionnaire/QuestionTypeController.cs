using Questionnaire.WEB.Models.Entities;
using Questionnaire.WEB.Models.Interfaces;
using Questionnaire.WEB.Models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Questionnaire.WEB.Controllers.Questionnaire
{
    public class QuestionTypeController : Controller
    {
        IUnitOfWork unitOfWork;

        public QuestionTypeController()
        {
            this.unitOfWork = new UnitOfWork();
        }
        public QuestionTypeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET: QuestionType
        public ActionResult Index()
        {
            var questionTypes = unitOfWork.QuestionTypes.GetAll();
            return View(questionTypes);
        }

        // GET: QuestionType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionType/Create
        [HttpPost]
        public ActionResult Create(QuestionType collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.QuestionTypes.Create(collection);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }

                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionType/Edit/5
        public ActionResult Edit(int id)
        {
            QuestionType questionType = unitOfWork.QuestionTypes.Get(id);
            if (questionType == null)
                return HttpNotFound();
            return View(questionType);
        }

        // POST: QuestionType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuestionType collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.QuestionTypes.Update(collection);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionType/Delete/5
        public ActionResult Delete(int id)
        {
            unitOfWork.QuestionTypes.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
