using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Areas.Admin.Models.Servisler.HTMLVeriKaynaklariServisleri;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class BlogPostController : BaseController
    {
        public int d = 0;
        public ActionResult Index()
        {

            List<BlogPostVM> model =
               db.BlogPosts.Where(x => x.Aktif == true).OrderBy(x => x.KayitTarihi).Select(x => new BlogPostVM()
               {
                   ID = x.ID,
                   blg_Baslik = x.blg_Baslik,
                   kat_ID = x.kat_ID,

                   kat_Adi = x.Kategori.kat_Adi

                   //kat_Adi = 


                   //= x.Aktif,
                   //KayitTarihi = x.KayitTarihi
               }).ToList();

            return View(model);
        }

        public ActionResult AddBlogPost()
        {
            BlogPostVM model = new BlogPostVM();
            model.drpKategoriler = DropDownList_Doldur.DDL_KategorileriGetir();
            //using MVCBlog.Areas.Admin.Models.Servisler.HTMLVeriKaynaklariServisleri; 
            // klasörüne doldurmak için class açtık 
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddBlogPost(BlogPostVM model)
        {
            BlogPostVM ddlmodel = new BlogPostVM();
            ddlmodel.drpKategoriler = DropDownList_Doldur.DDL_KategorileriGetir();


            if (ModelState.IsValid)
            {
                BlogPost blogpost = new BlogPost();
                blogpost.kat_ID = model.kat_ID;
                blogpost.blg_Baslik = model.blg_Baslik;
                blogpost.blg_Icerik = model.blg_Icerik;
                db.BlogPosts.Add(blogpost);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View(ddlmodel);
            }
            else
            {
                ViewBag.IslemDurum = 0;
                return View(ddlmodel);
            }
        }

        //kategori silme işlemi için
        //javascript aracılı ile yapıyoruz.
        public JsonResult DeleteBlogPost(int id)
        {
            BlogPost blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            blogpost.Aktif = false;
            blogpost.Degistirme_Tarihi = DateTime.Now;
            blogpost.Degistiren = 1;
            db.SaveChanges();

            return Json("");
        }


        public ActionResult UpdateBlogPost(int id)
        {
            //önce güncellenecek kaydı bulup ekrana verileri yazıyoruz
            BlogPost blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            BlogPostVM model = new BlogPostVM();


            model.drpKategoriler = DropDownList_Doldur.DDL_KategorileriGetir();

            model.blg_Baslik = blogpost.blg_Baslik;
            model.blg_Icerik = blogpost.blg_Icerik;
            model.kat_ID = blogpost.kat_ID;

            ViewBag.Guncelle = 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateBlogPost(BlogPostVM model)
        {
            BlogPostVM ddl_model = new BlogPostVM();
            ddl_model.drpKategoriler = DropDownList_Doldur.DDL_KategorileriGetir();

            //güncellenecek kategori alınır ve yeni verilerle güncellenir
            if (ModelState.IsValid)
            {
                BlogPost blogpost = db.BlogPosts.FirstOrDefault(x => x.ID == model.ID);



                blogpost.blg_Baslik = model.blg_Baslik;
                blogpost.blg_Icerik = model.blg_Icerik;
                blogpost.kat_ID = model.kat_ID;

                db.SaveChanges();
                ViewBag.IslemDurum = 1; // işlem durumuna göre mekranda öesaj göstermek için kullanıyoruz. Herhangi bir değişkene bağlı değil.
                //yani int IslemDurum=0; gibi bir tanımlaması yok.
                ViewBag.Guncelle = 1;
                return View(ddl_model);
            }
            else
            {
                ViewBag.IslemDurum = 0;
                return View(ddl_model);
            }


        }

    }
}