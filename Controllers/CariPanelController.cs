using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var email = (string)Session["CariMail"];
            var values = context.Mesajs.Where(x => x.Alici == email).ToList();
            var mailId = context.Caris.Where(x => x.CariMail == email).Select(y => y.CariId).FirstOrDefault();

            ViewBag.MailId = mailId;
            ViewBag.Email = email;

            var toplamSatis = context.SatisHarekets.Where(x => x.CariId == mailId).Count();
            ViewBag.ToplamSatis= toplamSatis;

            var toplamTutar = context.SatisHarekets.Where(x => x.CariId == mailId).Sum(y => y.ToplamTutar);
            ViewBag.ToplamTutar = toplamTutar;

            var toplamUrun = context.SatisHarekets.Where(x => x.CariId == mailId).Sum(y => y.Adet);
            ViewBag.ToplamUrun = toplamUrun;

            var adSoyad = context.Caris.Where(x => x.CariMail == email).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.AdSoyad = adSoyad;

            return View(values);
        }

        [Authorize]
        public ActionResult Siparislerim()
        {
            var email = (string)Session["CariMail"];
            var id = context.Caris.Where(x => x.CariMail == email.ToString()).Select(y => y.CariId).FirstOrDefault();
            var values = context.SatisHarekets.Where(x => x.CariId == id).ToList();

            return View(values);
        }

        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var email = (string)Session["CariMail"];
            var mesajlar = context.Mesajs.Where(x => x.Alici == email).OrderByDescending(x => x.Tarih).ToList();

            var gelenMesajSayisi = context.Mesajs.Where(x => x.Alici == email).ToList().Count();
            ViewBag.GelenMesajSayisi = gelenMesajSayisi;
            var gonderilenMesajSayisi = context.Mesajs.Where(x => x.Gonderici == email).ToList().Count();
            ViewBag.GonderilenMesajSayisi = gonderilenMesajSayisi;


            return View(mesajlar);
        }

        [Authorize]
        public ActionResult GonderilenMesajlar()
        {
            var email = (string)Session["CariMail"];
            var mesajlar = context.Mesajs.Where(x => x.Gonderici == email).OrderByDescending(x => x.Tarih).ToList();

            var gelenMesajSayisi = context.Mesajs.Where(x => x.Alici == email).ToList().Count();
            ViewBag.GelenMesajSayisi = gelenMesajSayisi;
            var gonderilenMesajSayisi = context.Mesajs.Where(x => x.Gonderici == email).ToList().Count();
            ViewBag.GonderilenMesajSayisi = gonderilenMesajSayisi;


            return View(mesajlar);
        }

        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = context.Mesajs.Where(x => x.MesajId == id).ToList();

            var email = (string)Session["CariMail"];

            var gelenMesajSayisi = context.Mesajs.Where(x => x.Alici == email).ToList().Count();
            ViewBag.GelenMesajSayisi = gelenMesajSayisi;
            var gonderilenMesajSayisi = context.Mesajs.Where(x => x.Gonderici == email).ToList().Count();
            ViewBag.GonderilenMesajSayisi = gonderilenMesajSayisi;

            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var email = (string)Session["CariMail"];
            var gelenMesajSayisi = context.Mesajs.Where(x => x.Alici == email).ToList().Count();
            ViewBag.GelenMesajSayisi = gelenMesajSayisi;
            var gonderilenMesajSayisi = context.Mesajs.Where(x => x.Gonderici == email).ToList().Count();
            ViewBag.GonderilenMesajSayisi = gonderilenMesajSayisi;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesaj mesaj)
        {
            var email = (string)Session["CariMail"];
            mesaj.Gonderici = email;
            mesaj.Tarih = DateTime.Now;
            context.Mesajs.Add(mesaj);
            context.SaveChanges();

            return RedirectToAction("GonderilenMesajlar");
        }

        [Authorize]
        public ActionResult KargoTakip(string p)
        {
            var k = from x in context.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p));

            return View(k.ToList());
        }

        [Authorize]
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();

            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


        public PartialViewResult Partial1()
        {
            var email = (string)Session["CariMail"];
            var id = context.Caris.Where(x => x.CariMail == email).Select(y => y.CariId).FirstOrDefault();
            var caribul = context.Caris.Find(id);

            return PartialView("Partial1", caribul);
        }

        public PartialViewResult Partial2()
        {
            var veriler = context.Mesajs.Where(x => x.Gonderici == "admin").ToList();

            return PartialView(veriler);
        }

        public ActionResult CariBilgiGuncelle(Cari cr)
        {
            var cari = context.Caris.Find(cr.CariId);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariSifre = cr.CariSifre;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}