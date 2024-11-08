using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Entities
{
    public class ToDo
    {
        [Key]
        public int ToDoId { get; set; }

        [Display(Name = "Başlık")]
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
    }
}