using MVCBlog.Areas.Admin.Models.Attributes;
using MVCBlog.Models.ORM.Context;
using MVCBlog.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    [LoginControl]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            //kullanıcı email ve ad soyadı çekme
            //login olduktan sonra alacak.

            BlogContext db = new BlogContext();
            string email = HttpContext.User.Identity.Name;
            AdminUser adminuser = db.AdminUsers.FirstOrDefault(x => x.adm_Email == email);
            string name = adminuser.adm_AdiSoyadi;
            int kullanicikodu = adminuser.ID;
            ViewBag.AktifKullaniciMail = email;
            ViewBag.AktifKullaniciAdi = name;
            ViewBag.AktifKullaniciKodu = kullanicikodu;
            return View();
        }







    }
}