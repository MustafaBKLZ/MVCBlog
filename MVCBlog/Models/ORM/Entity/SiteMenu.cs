using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class SiteMenu : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string smn_adi { get; set; }

        [Required]
        public string smn_url { get; set; }

        [Required]
        public string cssClass { get; set; }


    }
}