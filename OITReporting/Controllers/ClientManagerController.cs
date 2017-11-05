using OITReporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OITReporting.Controllers
{
    public class ClientManagerController : Controller
    {
        // GET: ClientManager
        public ActionResult Index()
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            return View(db.clientMasters.ToList());
        }

        [HttpGet]
        public ActionResult addClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addClient(clientMaster cm)
        {
            if (ModelState.IsValid)
            {
                dbOITReportingEntities db = new dbOITReportingEntities();
                db.clientMasters.Add(cm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.status = "Invalid Request";
            }
            return View();
        }

        [HttpGet]
        public ActionResult editClient(int id)
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            return View(db.clientMasters.Where(n => n.clientId.Equals(id)).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult editClient(clientMaster cm)
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            if (ModelState.IsValid)
            {
                db.Entry(cm).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.status = "Invalid request";
            }
            return View();
        }

        [HttpPost]
        public ActionResult deleteClient(int id, clientMaster cm)
        {
            dbOITReportingEntities db = new dbOITReportingEntities();
            var clients = db.clientMasters.Where(n => n.clientId.Equals(id)).FirstOrDefault();
            db.clientMasters.Remove(clients);
            db.SaveChanges();
            return View("Index");
        }
    }
}