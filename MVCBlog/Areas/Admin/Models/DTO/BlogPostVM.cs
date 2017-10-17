using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class BlogPostVM : BaseVM
    {
        [Required(ErrorMessage = "Başlık Boş Olamaz.")]
        public string blg_Baslik { get; set; }
        [Required(ErrorMessage = "İçerik Boş Olamaz.")]
        public string blg_Icerik { get; set; }
        [Required(ErrorMessage = "Kategori Seçiniz.")]
        public int kat_ID { get; set; }
        public IEnumerable<SelectListItem> drpKategoriler { get; set; }

        
        public string kat_Adi { get; set; }
    }
}