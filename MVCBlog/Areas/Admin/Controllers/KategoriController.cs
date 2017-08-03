using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class KategoriController : BaseController
    {
        // GET: Admin/Kategori
        //yorum satırlarını silme

        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(KategoriVM model)
        {
            if (ModelState.IsValid)
            {
                Kategori kategori = new Kategori();
                kategori.kat_Adi = model.kat_adi;
                kategori.kat_aciklama = model.kat_aciklama;
                kategori.Kaydeden = 1;
                db.Kategoriler.Add(kategori);
                db.SaveChanges();
                return View();
            }
            else
            {
                return View();
                //uyarılar gelecek
            }
            
        }









    }
}