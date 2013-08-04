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
    public class PickupController : Controller
    {
        private PickupDBContext db = new PickupDBContext(); 
        

        //
        // GET: /Status/

        public ViewResult Status()
        {
            PickupDB pickupdb = new PickupDB();
            pickupdb.ID = 1;
            return View(pickupdb);
        }

        //
        // GET: /Pickup/Details/5

        public ActionResult Details(int id)
        {
                PickupDB pickupdb = db.Pickup.Find(id);
                if (pickupdb != null)
                    return View(pickupdb);
                else
                {                   
                    return RedirectToAction("Error");                    
                }
        }

        public ViewResult Error()
        {
            return View();
        }

        //
        // GET: /Pickup/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Pickup/Create

        [HttpPost]
        public ActionResult Create(PickupDB pickupdb)
        {           
            List<string> PropertyNames = new List<string>() { "firstn", "lastn", "number", "address", "pincode" };

            if (PropertyNames.Any(p => !ModelState.IsValidField(p)))
            {              
                return View(pickupdb);                    // Error
            }
            else
            {                
                return RedirectToAction("Date", pickupdb);     // Everything is okay
            }
        }

        //
        // GET: /Pickup/Date

        public ActionResult Date()
        {
            return View();
        }

        //
        // POST: /Pickup/Date

        [HttpPost]
        public ActionResult Date(PickupDB pickupdb)
        {
            
            if (ModelState.IsValid)
            {
                db.Pickup.Add(pickupdb);                
                db.SaveChanges();
                return RedirectToAction("Confirm",pickupdb);
            }
            return View(pickupdb);
        }
        
        public ViewResult Confirm(PickupDB pickupdb)
        {
            return View(pickupdb);
        }

        //
        // GET: /Pickup/Edit/5
 
        public ActionResult Edit(int id)
        {
            PickupDB pickupdb = db.Pickup.Find(id);
            return View(pickupdb);
        }

        //
        // POST: /Pickup/Edit/5

        [HttpPost]
        public ActionResult Edit(PickupDB pickupdb)
        {
            List<string> PropertyNames = new List<string>() { "firstn", "lastn", "number", "address", "pincode" };
            if (PropertyNames.Any(p => !ModelState.IsValidField(p)))
            {
                return View(pickupdb);                    // Error
            }
            else
            {             
                db.Entry(pickupdb).State = EntityState.Modified;
                db.Configuration.ValidateOnSaveEnabled = false; 
                db.SaveChanges();                
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // GET: /Pickup/Delete/5
 
        public ActionResult Delete(int id)
        {
            PickupDB pickupdb = db.Pickup.Find(id);
            return View(pickupdb);
        }

        //
        // POST: /Pickup/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PickupDB pickupdb = db.Pickup.Find(id);
            db.Pickup.Remove(pickupdb);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}