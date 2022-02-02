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
    public class ServiceController : Controller
    {
        private GestionConsommationVehiculeEntities12 db = new GestionConsommationVehiculeEntities12();

        //
        // GET: /Service/

        public ActionResult  Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View(db.services.ToList());
        }

        //
        // GET: /Service/Details/5

        public ActionResult Details(int id = 0)
        {
            service service = db.services.Find(id);
            if (service == null)
            {
                 return HttpNotFound();
            }
            return View(service);
        }

        //
        // GET: /Service/Create


        public ActionResult Create()
        {
            TempData["msg"] = "Insertion faite avec Succes dans la table Service";
             return View();
        }

        //
        // POST: /Service/Create

        [HttpPost]
        public ActionResult Create(service service)
        {
            if (ModelState.IsValid)
            {
                 db.services.Add(service);
                 db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        //
        // GET: /Service/Edit/5

        public ActionResult Edit(int id = 0)
        {
            service  service = db.services.Find(id);
            if (service == null)
            {
                
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // POST: /Service/Edit/5

        [HttpPost]
        public ActionResult Edit(service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Modification faite avec Succes dans la table Service";
                return RedirectToAction("Index");
               
            }
            return View(service);
        }

        //
        // GET: /Service/Delete/5

        public ActionResult Delete(int id = 0)
        {
            service service = db.services.Find(id);
            if (service == null)
            
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // POST: /Service/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            service service = db.services.Find(id);
            db.services.Remove(service);
            db.SaveChanges();
            TempData["msg"] = "Suppression faite avec Succes dans la table Service";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}