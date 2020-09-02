using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PetStore.Models;

namespace PetStore.Controllers
{
    public class KorpaIgrackaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (db.KorpaIgracke.Count() > 0)
            {
                ViewBag.KorpaIgracke = db.KorpaIgracke.Include(x => x.Igracka);
                ViewBag.UkupnaCijena = db.KorpaIgracke.Sum(x => x.Igracka.Cijena * x.BrojKomada);
            }
            return View();
        }

        public ActionResult Dodaj(int id)
        {
            
            var igracka = db.Igracke.Find(id);
            ViewBag.Opis = igracka.Opis;
            ViewBag.Cijena = igracka.Cijena;
            return View();
        }

        [HttpPost]
        public ActionResult Dodaj(KorpaIgracka ki, int id)
        {
            ki.IgrackaId = id;
            if (ModelState.IsValid)
            {
                db.KorpaIgracke.Add(ki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ki);
        }

        [HttpPost]
        public ActionResult AzurirajBrojKomada(int id, int brKomada)
        {
            var ki = db.KorpaIgracke.Find(id);
            if (brKomada >= 1)
            {
                ki.BrojKomada = brKomada;
                db.Entry(ki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KorpaIgracke = db.KorpaIgracke.Include(x => x.Igracka);
            ViewBag.UkupnaCijena = db.KorpaIgracke.Sum(x => x.Igracka.Cijena * x.BrojKomada);
            return View();
        }
      
        [HttpPost]
        public ActionResult Kupi(Kupovina k)
        {
            ViewBag.KorpaIgracke = db.KorpaIgracke.Include(x => x.Igracka);
            ViewBag.UkupnaCijena = db.KorpaIgracke.Sum(x => x.Igracka.Cijena * x.BrojKomada);
            if (ModelState.IsValid && db.KorpaIgracke.Count() > 0)
            {
                db.Kupovine.Add(k);
           //     db.SaveChanges();
                foreach (var ki in db.KorpaIgracke)
                {
                    var kik = new KorpaIgrackaKupovina();
                    kik.KupovinaId = k.Id;
                    kik.KorpaIgrackaId = ki.Id;
                    db.KorpaIgrackaKupovine.Add(kik);
                    
                }
                db.SaveChanges();
                ModelState.Clear();
                TempData["Poruka"] = "Uspješno obavljena kupovina!";
                return View("Index");

            }
            
            return View("Index", k);
        }

        public ActionResult Obrisi(int id)
        {
            var ki = db.KorpaIgracke.Find(id);
            db.KorpaIgracke.Remove(ki);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}