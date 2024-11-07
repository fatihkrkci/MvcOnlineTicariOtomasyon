﻿using MvcOnlineTicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = context.Uruns.Where(x => x.UrunId == 1).ToList();
            cs.Deger2 = context.Detays.Where(y => y.DetayId == 1).ToList();

            return View(cs);
        }
    }
}