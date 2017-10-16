using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class BlogPostVM : BaseVM
    {
        public string blg_Baslik { get; set; }
        public string blg_Icerik { get; set; }
        [Required]
        public int kat_ID { get; set; }
        public IEnumerable<SelectListItem> drpKategoriler { get; set; }

    }
}