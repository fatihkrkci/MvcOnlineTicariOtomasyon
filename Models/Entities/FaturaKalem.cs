using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }

        [Display(Name = "Açıklama")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        
        [Display(Name = "Miktar")]
        public int Miktar { get; set; }

        [Display(Name = "Birim Fiyatı")]
        public decimal BirimFiyat { get; set; }

        [Display(Name = "Tutar")]
        public decimal Tutar { get; set; }
        public int FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}