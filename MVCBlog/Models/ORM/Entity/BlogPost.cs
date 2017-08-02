using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class BlogPost : BaseEntity
    {

        public string blg_Baslik { get; set; }
        public string blg_Icerik { get; set; }


        public int kat_ID { get; set; }
        [ForeignKey("kat_ID")]
        public virtual Kategori Kategori { get; set; }
    }
}