using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Adresi Alanı Boş Olamaz.")]
        [EmailAddress(ErrorMessage = "Email Adresi Yazımında Hata Var.")]
        public string adm_Email { get; set; }


        [Required(ErrorMessage = "Şifre Alanı Boş olamaz")]
        public string adm_Sifre { get; set; }


    }
}