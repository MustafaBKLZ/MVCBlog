using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class KategoriVM : BaseVM
    {
        [Required(ErrorMessage ="Kategori Adı Boş Olamaz.")]
        [Display(Name ="Kategori Adi")]
        public string kat_adi { get; set; }

        [Display(Name = "Kategori Açıklaması")]
        public string kat_aciklama { get; set; }

        public DateTime KayitTarihi { get; set; }
        public bool Aktif { get; set; }

    }
} 