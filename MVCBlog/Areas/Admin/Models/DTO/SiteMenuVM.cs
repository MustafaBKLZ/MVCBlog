using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Areas.Admin.Models.DTO
{
    public class SiteMenuVM : BaseVM
    {

        public string smn_adi { get; set; }
        public string smn_url { get; set; }
        public string cssClass { get; set; }

    }
}