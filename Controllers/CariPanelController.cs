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
    }
}