﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Class3
    {
        public IEnumerable<SelectListItem> Kategoriler { get; set; }
        public IEnumerable<SelectListItem> Urunler { get; set; }
    }
}