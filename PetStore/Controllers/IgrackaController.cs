using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PetStore.Models;
using PagedList;
using PagedList.Mvc;
namespace PetStore.Controllers
{
    public class IgrackaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page, string filter, int pageSize = 3)
        {
            ViewBag.filter = filter;
            if (string.IsNullOrEmpty(filter))
            {

                ViewBag.Igracke = db.Igracke.OrderBy(x => x.Id).ToPagedList(page ?? 1, pageSize);
            }
            else
            {
                ViewBag.Igracke = db.Igracke.Where(x => x.Opis.Contains(filter)).OrderBy(x => x.Id).ToPagedList(page ?? 1, pageSize);
            }
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult NovaIgracka(Igracka i)
        {
            ViewBag.Igracke = db.Igracke;
            if (ModelState.IsValid)
            {
                db.Igracke.Add(i);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }          
            return View("Index", i);
        }

        [Authorize]
        public ActionResult Izmijeni(int id)
        {
            var igracka = db.Igracke.Find(id);
            return View(igracka);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Izmijeni(Igracka i)
        {
            if (ModelState.IsValid)
            {
                db.Entry(i).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(i);
        }

        [Authorize]
        public ActionResult Obrisi(int id)
        {
            var igracka = db.Igracke.Find(id);
            db.Igracke.Remove(igracka);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}