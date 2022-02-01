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
    public class ProfileController : Controller
    {
        private GestionConsommationVehiculeEntities12 db = new GestionConsommationVehiculeEntities12();

        //
        // GET: /Profile/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            return View(db.profiles.ToList());
        }

        //
        // GET: /Profile/Details/5

        public ActionResult Details(int id = 0)
        {
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // GET: /Profile/Create

        public ActionResult Create()
        {
            TempData["msg"] = "Insertion faite avec Succes dans la table Profile";
            return View();
        }

        //
        // POST: /Profile/Create

        [HttpPost]
        public ActionResult Create(profile profile)
        {
            if (ModelState.IsValid)
            {
                db.profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        //
        // GET: /Profile/Edit/5

        public ActionResult Edit(int id = 0)
        {
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profile/Edit/5

        [HttpPost]
        public ActionResult  Edit(profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Modification faite avec Succes dans la table Profile";
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        //
        // GET: /Profile/Delete/5

        public ActionResult Delete(int id = 0)
        {
            profile profile = db.profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //
        // POST: /Profile/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            profile profile = db.profiles.Find(id);
            db.profiles.Remove(profile);
            db.SaveChanges();
            TempData["msg"] = "Suppression faite avec Succes dans la table Profile";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}