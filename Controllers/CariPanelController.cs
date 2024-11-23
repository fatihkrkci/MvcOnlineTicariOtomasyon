using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Siparislerim()
        {
            var email = (string)Session["CariMail"];
            var id = context.Caris.Where(x => x.CariMail == email.ToString()).Select(y => y.CariId).FirstOrDefault();
            var values = context.SatisHarekets.Where(x => x.CariId == id).ToList();

            return View(values);
        }

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
    }
}