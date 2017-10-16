using MVCBlog.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class BlogPostController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBlogPost()
        {
            BlogPostVM model = new BlogPostVM();
            model.drpKategoriler = db.Kategoriler.Select(x => new SelectListItem()
            {
                Text = x.kat_Adi,
                Value = x.ID.ToString()
            }).ToList();


            return View(model);
        }

        [HttpPost]
        public ActionResult AddBlogPost(BlogPostVM model)
        {
            if (ModelState.IsValid)
            {

                ViewBag.IslemDurumu = 1;
                return View();
            }
            else
            {

                ViewBag.IslemDurumu = 1;
                return View();
            }


        }
    }
}