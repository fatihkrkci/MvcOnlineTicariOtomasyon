using MvcOnlineTicariOtomasyon.Models.Entities;
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

        public ActionResult Index()
        {
            var products = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(products);
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
    }
}