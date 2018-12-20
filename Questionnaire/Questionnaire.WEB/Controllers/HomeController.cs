using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Questionnaire.WEB.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "admin, manager, user")]
        public ActionResult Index()
        {
            return View();
        }
    }
}