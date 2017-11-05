using OITReporting.Models;
using OITReporting.Models.dbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OITReporting.Controllers
{
    [Authorize]
    public class UserManagerController : Controller
    {
        [Authorize]
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
        public ActionResult addUser(userMaster um)
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            if (ModelState.IsValid)
            { 
                db.userMasters.Add(entity: um);
                db.SaveChanges();
                ViewBag.status = "User is Added";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.status = "Invalid Request";
            }
            return View();
        }
        [HttpGet]
        public ActionResult editUser(int id)
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            var user = db.userMasters.Where(n => n.userId.Equals(id)).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult editUser(userMaster um)
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            db.Entry(um).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View("Index");
        }

        [HttpPost]
        public ActionResult deleteUser()
        {
            return RedirectToAction("Index");
        }
    }
}