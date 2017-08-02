using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    public class Kategori : BaseEntity
    {
        [Required]
        public string kat_Adi { get; set; }
        public string  kat_aciklama { get; set; }
        public virtual List<BlogPost> BlogPosts { get; set; }
    }
}