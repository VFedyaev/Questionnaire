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
        // GET: QuestionType
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
