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
        public string kat_adi { get; set; }
        public string kat_aciklama { get; set; }
    }
} 