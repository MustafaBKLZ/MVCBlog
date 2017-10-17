using MVCBlog.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Models.Servisler.HTMLVeriKaynaklariServisleri
{
    public class DropDownList_Doldur
    {
        public static IEnumerable<SelectListItem> DDL_KategorileriGetir()
        {
            using (BlogContext db = new BlogContext())
            {
                IEnumerable<SelectListItem> ddl_kateogiler = db.Kategoriler.Select(x => new SelectListItem()
                {
                    Text = x.kat_Adi,
                    Value = x.ID.ToString()
                }).ToList();

                return ddl_kateogiler;
            }

        }
    }
}