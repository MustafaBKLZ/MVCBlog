using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class AdminUserVM : BaseVM
    {

        [Required(ErrorMessage = "Admin Email Boş Olamaz.")]
        [Display(Name = "Admin Email")]
        public string adm_Email { get; set; }

        [Required(ErrorMessage = "Admin Adı Boş Olamaz.")]
        [Display(Name = "Admin Adı")]
        public string adm_AdiSoyadi { get; set; }

        [Required(ErrorMessage = "Admin Şifre Boş Olamaz.")]
        [Display(Name = "Admin Şifre")]
        public string adm_Sifre { get; set; }

        public DateTime KayitTarihi { get; set; }

        public bool Aktif { get; set; }

    }
}