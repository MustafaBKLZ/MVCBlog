using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class SiteBilgileriVM : BaseVM
    {

        [Required(ErrorMessage = "Başlık Boş Olamaz.")]
        public string SiteBaslik { get; set; }
        [Required(ErrorMessage = "Açıklama Boş Olamaz.")]
        public string SiteAciklama { get; set; }



        public string SiteKeywords { get; set; }

        public int SiteYenilemeSuresi { get; set; }
    }
}