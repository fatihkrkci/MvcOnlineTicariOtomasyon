using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        [Display(Name = "Cari Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz!")]
        public string CariAd { get; set; }

        [Display(Name = "Cari Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CariSoyad { get; set; }

        [Display(Name = "Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Display(Name = "E-Mail Adresi")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Display(Name = "Şifre")]
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}