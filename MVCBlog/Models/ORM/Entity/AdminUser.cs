using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog.Models.ORM.Entity
{
    //yorum satırlarını silme
    public class AdminUser : BaseEntity
    {
        [Required]
        public int adm_ID { get; set; } // iki adet Id verdiğinde 2. ID normal kolon oluyor.

        [Required]  // zorunlu alanı bu şekilde belirtmek için
        [StringLength(100)] // sql de nvarchar(100) olarak ayarlar
        public string adm_Email { get; set; }

        [Required]
        [StringLength(20)] //max 20 karakter
        public string adm_Sifre { get; set; }

        [Required]
        [StringLength(50)]
        public string adm_AdiSoyadi { get; set; }
    }
}