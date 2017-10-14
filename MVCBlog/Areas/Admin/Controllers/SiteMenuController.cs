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
            SiteMenu sitemenu = new SiteMenu();

            sitemenu.smn_adi = model.smn_adi;
            sitemenu.smn_url = model.smn_url;
            sitemenu.cssClass = model.cssClass;

            sitemenu.Kaydeden = 1;
            sitemenu.Aktif = true;
            sitemenu.KayitTarihi = DateTime.Now;

            db.SiteMenus.Add(sitemenu);
            db.SaveChanges();

            ViewBag.IslemDurum = 1;

            return View();
        }
    }
}