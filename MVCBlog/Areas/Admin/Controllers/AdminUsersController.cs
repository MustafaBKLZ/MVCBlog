using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class AdminUsersController : BaseController
    {
        // GET: Admin/AdminUsers
        public ActionResult Index()
        {
            List<AdminUserVM> model =
                db.AdminUsers.Where(x => x.Aktif == true).OrderBy(x => x.KayitTarihi).Select(x => new AdminUserVM()
                {
                    ID = x.ID,
                    adm_Email = x.adm_Email,
                    adm_Sifre = x.adm_Sifre,
                    adm_AdiSoyadi = x.adm_AdiSoyadi,
                    Aktif = x.Aktif,
                    KayitTarihi = x.KayitTarihi
                }).ToList();

            return View(model);
        }

        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(AdminUserVM model)
        {
            if (ModelState.IsValid)
            {
                AdminUser Admin = new AdminUser();
                Admin.adm_AdiSoyadi = model.adm_AdiSoyadi;
                Admin.adm_Email = model.adm_Email;
                Admin.adm_Sifre = model.adm_Sifre;
                Admin.Kaydeden = 1;
                db.AdminUsers.Add(Admin);
                db.SaveChanges();
                ViewBag.IslemDurum = 1; // işlem durumuna göre mekranda öesaj göstermek için kullanıyoruz. Herhangi bir değişkene bağlı değil.
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
        public JsonResult AdminSil(int id)
        {
            AdminUser Admin = db.AdminUsers.FirstOrDefault(x => x.ID == id);
            Admin.Aktif = false;
            Admin.Degistirme_Tarihi = DateTime.Now;
            Admin.Degistiren = 1;
            db.SaveChanges();

            return Json("");
        }


        public ActionResult AdminGuncelle(int id)
        {
            //önce güncellenecek kaydı bulup ekrana verileri yazıyoruz
            AdminUser admin = db.AdminUsers.FirstOrDefault(x => x.ID == id);
            AdminUserVM model = new AdminUserVM();
            model.adm_AdiSoyadi = admin.adm_AdiSoyadi;
            model.adm_Email = admin.adm_Email;
            model.adm_Sifre = admin.adm_Sifre;

            return View(model);
        }

        [HttpPost]
        public ActionResult AdminGuncelle(AdminUserVM model)
        {
            //güncellenecek kategori alınır ve yeni verilerle güncellenir
            if (ModelState.IsValid)
            {
                AdminUser admin = db.AdminUsers.FirstOrDefault(x => x.ID == model.ID);
                admin.adm_AdiSoyadi = model.adm_AdiSoyadi;
                admin.adm_Email = model.adm_Email;
                admin.adm_Sifre = model.adm_Sifre;
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