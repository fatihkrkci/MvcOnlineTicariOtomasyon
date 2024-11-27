using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var satislar = context.SatisHarekets.OrderByDescending(x => x.SatisHareketId).ToList();
            return View(satislar);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> urunList = (from x in context.Uruns.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.UrunAd,
                                                      Value = x.UrunId.ToString()
                                                  }).ToList();
            ViewBag.UrunList = urunList;

            List<SelectListItem> cariList = (from x in context.Caris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAd + " " + x.CariSoyad,
                                                 Value = x.CariId.ToString()
                                             }).ToList();
            ViewBag.CariList = cariList;

            List<SelectListItem> personelList = (from x in context.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();
            ViewBag.PersonelList = personelList;

            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Now;
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> urunList = (from x in context.Uruns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAd,
                                                 Value = x.UrunId.ToString()
                                             }).ToList();
            ViewBag.UrunList = urunList;

            List<SelectListItem> cariList = (from x in context.Caris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAd + " " + x.CariSoyad,
                                                 Value = x.CariId.ToString()
                                             }).ToList();
            ViewBag.CariList = cariList;

            List<SelectListItem> personelList = (from x in context.Personels.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                     Value = x.PersonelId.ToString()
                                                 }).ToList();
            ViewBag.PersonelList = personelList;

            var satis = context.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            var existSatis = context.SatisHarekets.Find(satisHareket.SatisHareketId);
            existSatis.CariId = satisHareket.CariId;
            existSatis.Adet = satisHareket.Adet;
            existSatis.Fiyat = satisHareket.Fiyat;
            existSatis.PersonelId = satisHareket.PersonelId;
            existSatis.Tarih = DateTime.Now;
            existSatis.ToplamTutar = satisHareket.ToplamTutar;
            existSatis.UrunId = satisHareket.UrunId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var values = context.SatisHarekets.Where(x => x.SatisHareketId == id).ToList();
            return View(values);
        }

        public ActionResult UrunListesi()
        {
            var values = context.Uruns.ToList();
            return View(values);
        }
    }
}