using OITReporting.Models;
using OITReporting.Models.dbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OITReporting.Controllers
{
    public class UserManagerController : Controller
    {
        // GET: UserManager
        public ActionResult Index()
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            var user = db.userMasters.ToList();
            return View(user);
        }

        [HttpGet]
        public ActionResult addUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addUser(userReg ur)
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            if (ModelState.IsValid)
            {
                userMaster um = new userMaster();
                db.userMasters.Add(entity: um);
                db.SaveChanges();
                ViewBag.status = "User is Added";
            }
            else
            {
                ViewBag.status = "Invalid Request";
            }
            return View();
        }
    }
}