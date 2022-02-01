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
    public class AffectationController : Controller
    {
        private GestionConsommationVehiculeEntities12 db = new GestionConsommationVehiculeEntities12();

        //
        // GET: /Affectation/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            var affectations = db.affectations.Include(a => a.service).Include(a => a.utilisateur).Include(a => a.vehicule);
            return View(affectations.ToList());
        }

        //
        // GET: /Affectation/Details/5

        public ActionResult Details(int id = 0)
        {
            affectation affectation = db.affectations.Find(id);
            if (affectation == null)
            {
                return HttpNotFound();
            }
            return View(affectation);
        }

        //
        // GET: /Affectation/Create

        public ActionResult Create()
        {
            
            ViewBag.IdService = new SelectList(db.services, "Id", "NomService");
            ViewBag.IdUser = new SelectList(db.utilisateurs, "Id", "Nom");
            ViewBag.IdVehicule = new SelectList(db.vehicules, "Id", "NumeroImatriculation");
            return View();
        }

        //
        // POST: /Affectation/Create

        [HttpPost]
        public ActionResult Create(affectation affectation)
        {
            if (ModelState.IsValid)
            {
                db.affectations.Add(affectation);
                db.SaveChanges();
                TempData["msg"] = "Insertion faite avec Succes dans la table Affectation";
                return RedirectToAction("Index");
            }

            ViewBag.IdService = new SelectList(db.services, "Id", "NomService", affectation.IdService);
            ViewBag.IdUser = new SelectList(db.utilisateurs, "Id", "Nom", affectation.IdUser);
            ViewBag.IdVehicule = new SelectList(db.vehicules, "Id", "NumeroImatriculation", affectation.IdVehicule);
            return View(affectation);
        }

        //public ActionResult Index1()
        //{
        //    List<ModeleAffectation> model = (from A in db.affectations join V in db.vehicules on A.IdVehicule equals
        //                                      V.Id
        //                                     where parseInt(A.occupe) = 1
                                              
        //                                      select new ConsommationModele
                                              
        //                                      {
        //                                          plaque =V.NumeroImatriculation, 
        //                                          marque = V.marque,
        //                                          modele=V.modele,
        //                                          couleur=V.couleur,
                                                  


        //                                      }).ToList();
        //    return View(model);
        //}

        
        // GET: /Affectation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            affectation affectation = db.affectations.Find(id);
            if (affectation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdService = new SelectList(db.services, "Id", "NomService", affectation.IdService);
            ViewBag.IdUser = new SelectList(db.utilisateurs, "Id", "Nom", affectation.IdUser);
            ViewBag.IdVehicule = new SelectList(db.vehicules, "Id", "NumeroImatriculation", affectation.IdVehicule);
            return View(affectation);
        }


        //
        // POST: /Affectation/Edit/5

        [HttpPost]
        public ActionResult Edit(affectation affectation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(affectation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdService = new SelectList(db.services, "Id", "NomService", affectation.IdService);
            ViewBag.IdUser = new SelectList(db.utilisateurs, "Id", "Nom", affectation.IdUser);
            ViewBag.IdVehicule = new SelectList(db.vehicules, "Id", "NumeroImatriculation", affectation.IdVehicule);
            return View(affectation);
        }

        //
        // GET: /Affectation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            affectation affectation = db.affectations.Find(id);
            if (affectation == null)
            {
                return HttpNotFound();
            }
            return View(affectation);
        }

        //
        // POST: /Affectation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            affectation affectation = db.affectations.Find(id);
            db.affectations.Remove(affectation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}