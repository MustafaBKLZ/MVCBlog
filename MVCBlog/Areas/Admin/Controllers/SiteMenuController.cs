using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{

    public class SiteMenuController : BaseController
    {

        public ActionResult AddSiteMenu()
        {

            return View();

        }


        [HttpPost]
        public ActionResult AddSiteMenu(SiteMenuVM model)
        {
            if (ModelState.IsValid)
            {
                SiteMenu sitemenu = new SiteMenu();
                sitemenu.smn_adi = model.smn_adi;
                sitemenu.smn_url = model.smn_url;
                sitemenu.cssClass = model.cssClass;
                sitemenu.Kaydeden = 1;
                db.SiteMenus.Add(sitemenu);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                // işlem durumuna göre mekranda mesaj göstermek için kullanıyoruz. Herhangi bir değişkene bağlı değil.
                //yani int IslemDurum=0; gibi bir tanımlaması yok.
                return View();
            }
            else
            {
                ViewBag.IslemDurum = 0;
                return View();
                //uyarılar gelecek
            }
        }
    }
}