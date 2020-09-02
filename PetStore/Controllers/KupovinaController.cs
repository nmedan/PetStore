using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetStore.Models;
using System.Net;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
namespace PetStore.Controllers
{
    public class KupovinaController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        public ActionResult Index(int? page, int pageSize = 3)
        {
            ViewBag.Kupovine = db.Kupovine.OrderBy(x=>x.Id).ToPagedList(page ?? 1, pageSize);         
            return View();
        }

        [Authorize]
        public ActionResult Obrisi(int id)
        {
            var kupovina = db.Kupovine.Find(id);
            db.Kupovine.Remove(kupovina);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult PregledArtikala (int id)
        {
            var kupovina = db.Kupovine.Find(id);
            var artikli = db.KorpaIgrackaKupovine.Where(x => x.KupovinaId == id).Include(x => x.KorpaIgracka);
            var artikliPrikaz = db.KorpaIgracke.Include(x => x.Igracka).Where(x => artikli.Any(y => y.KorpaIgrackaId == x.Id));
            ViewBag.Kupac = kupovina.KupacIme + " " + kupovina.KupacPrezime;
            ViewBag.UkupnaCijena = db.KorpaIgracke.Sum(x => x.Igracka.Cijena * x.BrojKomada);
            ViewBag.KupovinaId = kupovina.Id;
            return View(artikliPrikaz);
        }
    }
}