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
    public class UtilisateurController : Controller
    {
        private GestionConsommationVehiculeEntities12 db = new GestionConsommationVehiculeEntities12();

        //
        // GET: /Utilisateur/

        public ActionResult Index()
        {
            ViewBag.msg = TempData["msg"] as string;
            var utilisateurs  = db.utilisateurs.Include(u => u.profile).Include(u => u.service);
            return View(utilisateurs.ToList());
        }
        public ActionResult Index1()
        {
            var utilisateurs = db.utilisateurs.Include(u => u.profile).Include(u => u.service);
             return View(utilisateurs.ToList());
        }

        //
        // GET: /Utilisateur/Details/5

        public ActionResult Details(int id = 0)
        {
            utilisateur utilisateur = db.utilisateurs.Find(id);

            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }
        //login
        public ActionResult   Login(utilisateur user)
        {
            var v = from p in db.profiles
                    join u in db.utilisateurs
                        on p.Id equals u.IdProfile
                    where (u.username == user.username && u.password == user.password)
                    select new
                    {
                        profile_name = p.NomProfile,
                        username = u.username,
                        password = u.password,
                        telephone = u.telephone,
                        email = u.email
                    };

            var result = v.FirstOrDefault();

            if (result != null)
            {
                TempData["msg"] = "Vous venez Inserer avec Succes";
                Session["username"] = result.username;
                Session["password"] = result.password;
                Session["telephone"] = result.telephone;
                Session["email"] = result.email;
                if (result.profile_name == "Admin")
                {
                    TempData["msg"] = " Bienvue La Connection est Reussie";
                    return RedirectToAction("Index3", "Consommation");
                }
                else if (result.profile_name == "User")
                {
                    TempData["msg"] = " Bienvue La Connection est Reussie";
                    return RedirectToAction("Index5", "Consommation");
                }
                else
                {
                    TempData["msg"] = "Bienvue La Connection est Reussie";
                    return RedirectToAction("Index1", "Vehicule");
                }
            }

            return View(user);
        }


        //
        // GET: /Utilisateur/Create

        public ActionResult Create()
        {
            TempData["msg"] = "Insertion faite avec Succes dans la table Utilisateur";
            ViewBag.IdProfile = new SelectList(db.profiles, "Id", "NomProfile");
            ViewBag.IdService = new SelectList(db.services, "Id", "NomService");
            return View();
        }

        //
        // POST: /Utilisateur/Create

        [HttpPost]
        public ActionResult Create(utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.utilisateurs.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProfile = new SelectList(db.profiles, "Id", "NomProfile", utilisateur.IdProfile);
            ViewBag.IdService = new SelectList(db.services, "Id", "NomService", utilisateur.IdService);
            return View(utilisateur);
        }

        //
        // GET: /Utilisateur/Edit/5

        public ActionResult Edit(int id = 0)
        {


            utilisateur utilisateur = db.utilisateurs.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProfile = new SelectList(db.profiles, "Id", "NomProfile", utilisateur.IdProfile);
            ViewBag.IdService = new SelectList(db.services, "Id", "NomService", utilisateur.IdService);
            return View(utilisateur);
        }

        //
        // POST: /Utilisateur/Edit/5

        [HttpPost]
        public ActionResult Edit(utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                db.SaveChanges();
                TempData["msg"] = "Modification faite avec Succes dans la table Utilisateur";
                return RedirectToAction("Index");
            }
            ViewBag.IdProfile = new SelectList(db.profiles, "Id", "NomProfile", utilisateur.IdProfile);
            ViewBag.IdService = new SelectList(db.services, "Id", "NomService", utilisateur.IdService);
            return View(utilisateur);
        }

        //
        // GET: /Utilisateur/Delete/5

        public ActionResult Delete(int id = 0)
        {
            utilisateur utilisateur = db.utilisateurs.Find(id);
            if (utilisateur == null)
            {
                
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        //
        // POST: /Utilisateur/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            utilisateur utilisateur = db.utilisateurs.Find(id);
            db.utilisateurs.Remove(utilisateur);
            db.SaveChanges();
            TempData["msg"] = "Suppression faite avec Succes dans la table Utilisateur";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}