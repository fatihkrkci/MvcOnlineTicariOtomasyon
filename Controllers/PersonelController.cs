using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var personeller = context.Personels.ToList();
            return View(personeller);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmanList = (from x in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.DepartmanList = departmanList;

            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departmanList = (from x in context.Departmans.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.DepartmanAd,
                                                      Value = x.DepartmanId.ToString()
                                                  }).ToList();
            ViewBag.DepartmanList = departmanList;

            var personel = context.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            var existPersonel = context.Personels.Find(personel.PersonelId);
            existPersonel.PersonelAd = personel.PersonelAd;
            existPersonel.PersonelSoyad = personel.PersonelSoyad;
            existPersonel.PersonelGorsel = personel.PersonelGorsel;
            existPersonel.DepartmanId = personel.DepartmanId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}