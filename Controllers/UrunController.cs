using MvcOnlineTicariOtomasyon.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();

        public ActionResult Index(string p)
        {
            var products = context.Uruns.Where(x => x.Durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                products = products.Where(y => y.UrunAd.Contains(p));
            }

            var allProducts = products.OrderByDescending(x => x.UrunId).ToList();
            return View(allProducts);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> categoryList = (from x in context.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.KategoriId.ToString()
                                                 }).ToList();
            ViewBag.CategoryList = categoryList;

            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            urun.Durum = true;
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var product = context.Uruns.Find(id);
            product.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> categoryList = (from x in context.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.KategoriId.ToString()
                                                 }).ToList();
            ViewBag.CategoryList = categoryList;

            var product = context.Uruns.Find(id);
            return View("UrunGetir", product);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var existProduct = context.Uruns.Find(urun.UrunId);
            existProduct.AlisFiyat = urun.AlisFiyat;
            existProduct.Durum = urun.Durum;
            existProduct.KategoriId = urun.KategoriId;
            existProduct.Marka = urun.Marka;
            existProduct.SatisFiyat = urun.SatisFiyat;
            existProduct.Stok = urun.Stok;
            existProduct.UrunAd = urun.UrunAd;
            existProduct.UrunGorsel = urun.UrunGorsel;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personelList = (from x in context.Personels.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                     Value = x.PersonelId.ToString()
                                                 }).ToList();
            ViewBag.PersonelList = personelList;

            var urun = context.Uruns.Find(id);
            ViewBag.UrunID = urun.UrunId;
            ViewBag.UrunFiyat = urun.SatisFiyat;

            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }
    }
}