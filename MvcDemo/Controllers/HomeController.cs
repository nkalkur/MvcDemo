using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private PickupDBContext db = new PickupDBContext();

        public ActionResult Index()
        {
            PickupDB pickupdb = new PickupDB();
            pickupdb.ID = 1;
            return View(pickupdb); 
        }

        public ActionResult About()
        { return View(); }

        [HttpGet]
        public ActionResult Complaint(int id)
        {
            PickupDB pickupdb = db.Pickup.Find(id);
            if (pickupdb == null)
                return RedirectToAction("Error", "Pickup");
            return View(pickupdb); 
        }

        [HttpPost]
        public ActionResult Complaint(PickupDB pickupdb)                                
        {
                db.Entry(pickupdb).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                return RedirectToAction("Review");            
        }

        public ViewResult Review()
        {
            return View(db.Pickup.ToList());
        }
    }
}
