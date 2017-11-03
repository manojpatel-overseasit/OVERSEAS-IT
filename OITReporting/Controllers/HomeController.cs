using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OITReporting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
        
        public ActionResult events()
        {
            return View();
        }

        public ActionResult photoGalary()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult faq()
        {
            return View();
        }
    }
}