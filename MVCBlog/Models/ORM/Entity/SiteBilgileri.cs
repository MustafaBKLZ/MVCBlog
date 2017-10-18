using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class SiteBilgileri : BaseEntity
    {
        [Required]
        public string SiteBaslik { get; set; }
        [Required]
        public string SiteAciklama { get; set; }
        public string SiteKeywords { get; set; }
        public int SiteYenilemeSuresi { get; set; }
    }
}