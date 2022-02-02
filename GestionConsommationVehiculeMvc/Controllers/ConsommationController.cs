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
    public class ConsommationController : Controller
    {
        private GestionConsommationVehiculeEntities12 db = new GestionConsommationVehiculeEntities12();
        //
        // GET: /Consommation/
        public ActionResult Index3()
        {
            ViewBag.msg = TempData["msg"] as string;
            var consommations = db.consommations.Include(c => c.typeconsommation).Include(c => c.vehicule);
            return View(consommations.ToList());
        }

        public ActionResult Index( )
        {
            ViewBag.msg = TempData["msg"] as string;
            var consommations = db.consommations.Include(c => c.typeconsommation).Include(c => c.vehicule);
            return View(consommations.ToList());
        }
         [HttpPost]
        public ActionResult Index(DateTime? datedebut,DateTime?datefin)
        {
            ViewBag.Rapports = "Rapport detaille du:" + datedebut +  "Au"   + datefin;
            var consommations = db.consommations.Where(c => c.DateConsommation >= datedebut && c.DateConsommation <= datefin).ToList();
            return View(consommations);
        }
         public ActionResult Index4()
         {
             ViewBag.msg = TempData["msg"] as string;
             var consommations = db.consommations.Include(c => c.typeconsommation).Include(c => c.vehicule);
             return View(consommations.ToList());
         }
         [HttpPost]
         public ActionResult Index4(DateTime? datedebut, DateTime? datefin)
         {
             ViewBag.Rapport = "Rapport detaille du:" + datedebut + "Au" + datefin;
             var consommations = db.consommations.Where(c => c.DateConsommation >= datedebut && c.DateConsommation <= datefin).ToList();
             return View(consommations);
         }
        public ActionResult Index1()
        {
            List<ConsommationModele> model = (from K in db.consommations
                                              join Ve in db.vehicules on K.IdVehicule equals Ve.Id 
                                              select new { K.IdVehicule, Ve.NumeroImatriculation, K.PrixTotal,K.DateConsommation } into x
                                              group x by new { x.DateConsommation } into g
                                              select new ConsommationModele
                                              {
                                                 
                                                  DateConsommation = (g.Key.DateConsommation),
                                                  prixtotal = (g.Select(x => x.PrixTotal).Sum()),
                                                  //factura = (g.Select(x => x.facturationID).Count()),
                                              }).ToList();
            return View(model);
        }
        public ActionResult Index5()
        {
            ViewBag.msg = TempData["msg"] as string;
            List<ConsommationModele> model = (from K in db.consommations
                                              join Ve in db.vehicules on K.IdVehicule equals Ve.Id
                                              select new { K.IdVehicule, Ve.NumeroImatriculation, K.PrixTotal, K.DateConsommation } into x
                                              group x by new { x.DateConsommation } into g
                                              select new ConsommationModele
                                              {
                                                  DateConsommation = (g.Key.DateConsommation),
                                                  prixtotal =(g.Select(x => x.PrixTotal).Sum()),
                                                  //factura = (g.Select(x => x.facturationID).Count()),
                                              }).ToList();
            return View(model);
        }
       
        public ActionResult  Index2()
        {
            List<ConsommationModele> model = (from K in db.consommations
                                              join Ve in db.vehicules on K.IdVehicule equals Ve.Id
                                              select new { K.IdVehicule, Ve.NumeroImatriculation, K.PrixTotal } into x
                                              group x by new { x.NumeroImatriculation } into g
                                              select new ConsommationModele
                                              {
                                                  plaque = (g.Key.NumeroImatriculation),
                                                  prixtotal = (g.Select(x => x.PrixTotal).Sum()),
                                                  //factura = (g.Select(x => x.facturationID).Count()),
                                              }).ToList();
            return View(model);
        }

        //
        // GET: /Consommation/Details/5

        public ActionResult Details(int id = 0)
        {
            consommation consommation = db.consommations.Find(id);
            if (consommation == null)
            {
                return HttpNotFound();
            }
            return View(consommation);
        }

        //
        // GET: /Consommation/Create

        public ActionResult Create()
        {
            TempData["msg"] ="Insertion faite avec Succes dans consommation";
            ViewBag.IdTypeConsommation = new SelectList(db.typeconsommations, "Id", "NomTypeConsommation");
            ViewBag.IdVehicule = new SelectList(db.vehicules, "Id", "NumeroImatriculation");
            return View();
        }

        //
        // POST: /Consommation/Create

        [HttpPost]
        public ActionResult Create(consommation consommation)
        {
            if (ModelState.IsValid)
            {
                db.consommations.Add(consommation);
                db.SaveChanges();
                return RedirectToAction("Index3");
            }

            ViewBag.IdTypeConsommation = new SelectList(db.typeconsommations, "Id", "NomTypeConsommation", consommation.IdTypeConsommation);
            ViewBag.IdVehicule = new SelectList(db.vehicules, "Id", "NumeroImatriculation", consommation.IdVehicule);
            return View(consommation);
        }

        //
        // GET: /Consommation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            consommation consommation = db.consommations.Find(id);
            if (consommation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTypeConsommation = new SelectList(db.typeconsommations, "Id", "NomTypeConsommation", consommation.IdTypeConsommation);
            ViewBag.IdVehicule = new SelectList(db.vehicules, "Id", "NumeroImatriculation", consommation.IdVehicule);
            return View(consommation);
        }

        //
        // POST: /Consommation/Edit/5

        [HttpPost]
        public ActionResult Edit(consommation consommation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consommation).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Modification faite avec success";
                return RedirectToAction("Index3");
            }
            ViewBag.IdTypeConsommation = new SelectList(db.typeconsommations, "Id", "NomTypeConsommation", consommation.IdTypeConsommation);
            ViewBag.IdVehicule = new SelectList(db.vehicules, "Id", "NumeroImatriculation", consommation.IdVehicule);
            return View(consommation);
        }

        //
        // GET: /Consommation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            consommation consommation = db.consommations.Find(id);
            if (consommation == null)
            {
                return HttpNotFound();
            }
            return View(consommation);
        }

        //
        // POST: /Consommation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            consommation consommation = db.consommations.Find(id);
            db.consommations.Remove(consommation);
            db.SaveChanges();
            TempData["msg"] = "Suppression faite avec success";
            return RedirectToAction("Index3");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}