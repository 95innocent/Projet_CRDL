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
    public class TypeConsommationController : Controller
    {
        private GestionConsommationVehiculeEntities12 db = new GestionConsommationVehiculeEntities12();

        //
        // GET: /TypeConsommation/

        public ActionResult  Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View(db.typeconsommations.ToList());
        }

        //
        // GET: /TypeConsommation/Details/5


        public ActionResult   Details(int id = 0)
        {
            typeconsommation typeconsommation = db.typeconsommations.Find(id);
            if (typeconsommation == null)
            {
                return HttpNotFound();
            }
            return View(typeconsommation);
        }

        //
        // GET: /TypeConsommation/Create

        public ActionResult Create()
        {
            TempData["msg"] = "Insertion faite avec Succes dans la table TypeConsommation";
            return View();
        }

        //
        // POST: /TypeConsommation/Create

        [HttpPost]
        public ActionResult Create(typeconsommation typeconsommation)
        {
            if (ModelState.IsValid)
            {
                
                db.typeconsommations.Add(typeconsommation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeconsommation);
        }

        //
        // GET: /TypeConsommation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            typeconsommation typeconsommation = db.typeconsommations.Find(id);
            if  (typeconsommation == null)
            {
                
                return HttpNotFound();
            }
            return View(typeconsommation);
        }

        //
        // POST: /TypeConsommation/Edit/5

        [HttpPost]
        public ActionResult Edit(typeconsommation typeconsommation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeconsommation).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Modification faite avec Succes dans la table TypeConsommation";
                return RedirectToAction("Index");
            }
            return View(typeconsommation);
        }

        //
        // GET: /TypeConsommation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            typeconsommation typeconsommation = db.typeconsommations.Find(id);
            if (typeconsommation == null)
            {
                return HttpNotFound();

            }
            return View(typeconsommation);
        }

        //
        // POST: /TypeConsommation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            typeconsommation typeconsommation = db.typeconsommations.Find(id);
            db.typeconsommations.Remove(typeconsommation);
            db.SaveChanges();
            TempData["msg"] = "Suppression faite avec Succes dans la table TypeConsommation";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}