using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Context;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class SiteBilgileriController : BaseController
    {
        // GET: Admin/SiteBilgileri
        public ActionResult Index()
        {
            List<SiteBilgileriVM> model =
              db.SiteBilgileris.Where(x => x.Aktif == true).Select(x => new SiteBilgileriVM()
              {
                  ID = x.ID,
                  SiteAciklama = x.SiteAciklama,
                  SiteBaslik = x.SiteBaslik,
                  SiteKeywords = x.SiteKeywords,
                  SiteYenilemeSuresi = x.SiteYenilemeSuresi

              }).ToList();

            return View(model);
        }
        public ActionResult SitebilgileriKaydet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SitebilgileriKaydet(SiteBilgileriVM model)
        {
            if (ModelState.IsValid)
            {
                SiteBilgileri sitebilgileri = new SiteBilgileri()
                {
                    SiteBaslik = model.SiteBaslik,
                    SiteAciklama = model.SiteAciklama,
                    SiteKeywords = model.SiteKeywords,
                    SiteYenilemeSuresi = model.SiteYenilemeSuresi,
                    Kaydeden = ViewBag.AktifKullaniciKodu
                };
                db.SiteBilgileris.Add(sitebilgileri);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View();
            }
            else
            {
                ViewBag.IslemDurum = 0;
                return View();
            }
        }

        public ActionResult SitebilgileriGuncelle(int id)
        {
            //önce güncellenecek kaydı bulup ekrana verileri yazıyoruz
            SiteBilgileri sitebilgileri = db.SiteBilgileris.FirstOrDefault(x => x.ID == id);
            SiteBilgileriVM model = new SiteBilgileriVM()
            {
                SiteBaslik = sitebilgileri.SiteBaslik,
                SiteAciklama = sitebilgileri.SiteAciklama,
                SiteYenilemeSuresi = sitebilgileri.SiteYenilemeSuresi,
                SiteKeywords = sitebilgileri.SiteKeywords
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SitebilgileriGuncelle(SiteBilgileriVM model)
        {
            //güncellenecek kategori alınır ve yeni verilerle güncellenir
            if (ModelState.IsValid)
            {
                SiteBilgileri sitebilgileri = db.SiteBilgileris.FirstOrDefault(x => x.ID == model.ID);
                sitebilgileri.SiteBaslik = model.SiteBaslik;
                sitebilgileri.SiteAciklama = model.SiteAciklama;
                sitebilgileri.SiteKeywords = model.SiteKeywords;
                sitebilgileri.SiteYenilemeSuresi = model.SiteYenilemeSuresi;
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