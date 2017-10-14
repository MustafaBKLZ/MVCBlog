using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class SiteMenuVM : BaseVM
    {
        [Required(ErrorMessage = "Site Menü Adı Boş Olamaz.")]
        public string smn_adi { get; set; }
        [Required(ErrorMessage = "Site Menü URL Boş Olamaz.")]
        public string smn_url { get; set; }
        [Required(ErrorMessage = "Site Menü Css Boş Olamaz.")]
        public string cssClass { get; set; }

        public DateTime KayitTarihi { get; set; }
        public bool Aktif { get; set; }
    }
}