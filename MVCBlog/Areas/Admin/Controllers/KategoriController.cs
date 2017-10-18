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

     

        public ActionResult Index()
        {
            List<KategoriVM> model =
                db.Kategoriler.Where(x => x.Aktif == true).OrderBy(x => x.KayitTarihi).Select(x => new KategoriVM()
                {
                    ID = x.ID,
                    kat_adi = x.kat_Adi,
                    kat_aciklama = x.kat_aciklama,
                    Aktif = x.Aktif,
                    KayitTarihi = x.KayitTarihi
                }).ToList();

            return View(model);
        }


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
                ViewBag.IslemDurum = 1;
                // işlem durumuna göre mekranda öesaj göstermek için kullanıyoruz. Herhangi bir değişkene bağlı değil.
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
        public JsonResult KategoriSil(int id)
        {
            Kategori kategori = db.Kategoriler.FirstOrDefault(x => x.ID == id);
            kategori.Aktif = false;
            kategori.Degistirme_Tarihi = DateTime.Now;
            kategori.Degistiren = 1;
            db.SaveChanges();

            return Json("");
        }




        public ActionResult KategoriGuncelle(int id)
        {
            //önce güncellenecek kaydı bulup ekrana verileri yazıyoruz
            Kategori kategori = db.Kategoriler.FirstOrDefault(x => x.ID == id);
            KategoriVM model = new KategoriVM();
            model.kat_adi = kategori.kat_Adi;
            model.kat_aciklama = kategori.kat_aciklama;

            return View(model);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(KategoriVM model)
        {
            //güncellenecek kategori alınır ve yeni verilerle güncellenir
            if (ModelState.IsValid)
            {
                Kategori kategori = db.Kategoriler.FirstOrDefault(x => x.ID == model.ID);
                kategori.kat_Adi = model.kat_adi;
                kategori.kat_aciklama = model.kat_aciklama;
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