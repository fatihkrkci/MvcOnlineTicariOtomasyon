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
            var values = context.Caris.FirstOrDefault(x => x.CariMail == email);

            ViewBag.email = email;

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
    }
}