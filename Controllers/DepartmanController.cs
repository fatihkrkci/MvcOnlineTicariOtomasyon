using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var departmans = context.Departmans.Where(x => x.Durum == true).ToList();
            return View(departmans);
        }

        [HttpGet]
        [Authorize(Roles = "A")]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = context.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var existDepartman = context.Departmans.Find(departman.DepartmanId);
            existDepartman.DepartmanAd = departman.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var personels = context.Personels.Where(x => x.DepartmanId == id).ToList();
            var departman = context.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.Departman = departman;
            return View(personels);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var values = context.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var personel = context.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.Personel = personel;
            return View(values);
        }
    }
}