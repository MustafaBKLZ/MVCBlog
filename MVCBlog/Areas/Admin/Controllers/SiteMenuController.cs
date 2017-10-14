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

        public ActionResult Index()
        {

            List<SiteMenuVM> model =
               db.SiteMenus.Where(x => x.Aktif == true).OrderBy(x => x.KayitTarihi).Select(x => new SiteMenuVM()
               {
                   ID = x.ID,
                   smn_adi = x.smn_adi,
                   smn_url = x.smn_url,
                   cssClass = x.cssClass,
                   KayitTarihi = x.KayitTarihi,
                   Aktif = x.Aktif
               }).ToList();

            return View(model);
        }






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



        //kategori silme işlemi için
        //javascript aracılı ile yapıyoruz.
        public JsonResult DeleteSiteMenu(int id)
        {
            SiteMenu sitemenu = db.SiteMenus.FirstOrDefault(x => x.ID == id);
            sitemenu.Aktif = false;
            sitemenu.Degistirme_Tarihi = DateTime.Now;
            sitemenu.Degistiren = 1;
            db.SaveChanges();

            return Json("");
        }



        public ActionResult UpdateSiteMenu(int id)
        {
            //önce güncellenecek kaydı bulup ekrana verileri yazıyoruz
            SiteMenu sitemenu = db.SiteMenus.FirstOrDefault(x => x.ID == id);
            SiteMenuVM model = new SiteMenuVM();
            model.smn_adi = sitemenu.smn_adi;
            model.smn_url = sitemenu.smn_url;
            model.cssClass = sitemenu.cssClass;
            

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateSiteMenu(SiteMenuVM model)
        {
            //güncellenecek kategori alınır ve yeni verilerle güncellenir
            if (ModelState.IsValid)
            {
                SiteMenu sitemenu = db.SiteMenus.FirstOrDefault(x => x.ID == model.ID);
                sitemenu.smn_adi = model.smn_adi;
                sitemenu.smn_url = model.smn_url;
                sitemenu.cssClass = model.cssClass;
                db.SaveChanges();
                ViewBag.IslemDurum = 1; // işlem durumuna göre mekranda öesaj göstermek için kullanıyoruz. Herhangi bir değişkene bağlı değil.
                //yani int IslemDurum=0; gibi bir tanımlaması yok.
                return View();
            }
            else
            {
                ViewBag.IslemDurum = 0;
                return View();
            }


        }

    }
}