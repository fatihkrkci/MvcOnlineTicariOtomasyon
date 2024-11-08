using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Display(Name = "Ürün Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }

        public short Stok { get; set; }

        [Display(Name = "Alış Fiyatı")]
        public decimal AlisFiyat { get; set; }

        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Display(Name = "Görsel")]
        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string UrunGorsel { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}