﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketId { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }

        [Display(Name = "Toplam Tutar")]
        public decimal ToplamTutar { get; set; }

        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }
        public int PersonelId { get; set; }
        public virtual Personel Personel { get; set; }
    }
}