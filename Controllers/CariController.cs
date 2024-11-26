using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var cariler = context.Caris.Where(x => x.Durum == true).OrderByDescending(y => y.CariId).ToList();
            return View(cariler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            context.Caris.Add(cari);
            cari.Durum = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = context.Caris.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = context.Caris.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var existCari = context.Caris.Find(cari.CariId);
            existCari.CariAd = cari.CariAd;
            existCari.CariSoyad = cari.CariSoyad;
            existCari.CariSehir = cari.CariSehir;
            existCari.CariMail = cari.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var values = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cari = context.Caris.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.Cari = cari;

            return View(values);
        }
    }
}