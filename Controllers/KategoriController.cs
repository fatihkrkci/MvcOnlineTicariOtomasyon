﻿using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var categories = context.Kategoris.ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var category = context.Kategoris.Find(id);
            context.Kategoris.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var category = context.Kategoris.Find(id);
            return View("KategoriGetir", category);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var existCategory = context.Kategoris.Find(kategori.KategoriId);
            existCategory.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}