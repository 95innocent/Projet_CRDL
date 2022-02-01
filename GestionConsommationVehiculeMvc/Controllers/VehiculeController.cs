using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionConsommationVehiculeMvc.Models;

namespace GestionConsommationVehiculeMvc.Controllers
{
    public class VehiculeController : Controller
    {
        private GestionConsommationVehiculeEntities12 db = new GestionConsommationVehiculeEntities12();

        //
        // GET: /Vehicule/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return  View(db.vehicules.ToList());
        }

        public ActionResult Index1()
        {
             return  View(db.vehicules.ToList());
        }
        //
        // GET: /Vehicule/Details/5

        public ActionResult Details(int id = 0)
        {
            vehicule  vehicule = db.vehicules.Find(id);
            if (vehicule == null)
            {
                 return HttpNotFound();
            }
            return View(vehicule);
        }

        //
        // GET: /Vehicule/Create

        public ActionResult Create()
        {
            TempData["msg"] = "Insertion faite avec Succes dans la table Vehicule";
            return View();
        }

        //
        // POST: /Vehicule/Create

        [HttpPost]
        public ActionResult Create(vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.vehicules.Add(vehicule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicule);
        }

        //
        // GET: /Vehicule/Edit/5

        public ActionResult Edit(int id = 0)
        {
            vehicule vehicule  = db.vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        //
        // POST: /Vehicule/Edit/5

        [HttpPost]
        public ActionResult Edit(vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicule).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Modification faite avec Succes dans la table Vehicule";
                return RedirectToAction("Index");
            }
            return View(vehicule);
        }

        //
        // GET: /Vehicule/Delete/5

        public ActionResult Delete(int id = 0)
        {
            vehicule   vehicule = db.vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        //
        // POST: /Vehicule/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicule vehicule = db.vehicules.Find(id);
            db.vehicules.Remove(vehicule);
            db.SaveChanges();
            TempData["msg"] = "Suppression faite avec Succes dans la table Vehicule";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}