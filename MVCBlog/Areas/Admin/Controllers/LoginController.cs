using MVCBlog.Areas.Admin.Models.DTO;
using MVCBlog.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.AdminUsers.Any(x => x.adm_Email == model.adm_Email && x.adm_Sifre == model.adm_Sifre && x.Aktif == true))
                {
                    FormsAuthentication.SetAuthCookie(model.adm_Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }

        }

        public ActionResult LogOff()
        {
            //FormsAuthentication.Timeout. = 1;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }




    }
}