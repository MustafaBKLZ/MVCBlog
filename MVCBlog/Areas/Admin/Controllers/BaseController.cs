using MVCBlog.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // yorum satırlarını silme
        // GET: Admin/Base
        // her controller de db tanıtımı yapmamak için ana bir controller açtık.
        // diğer tüm kontrollerlarda bunu kullanacağız
        public BlogContext db;
        public BaseController()
        {
            db = new BlogContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}