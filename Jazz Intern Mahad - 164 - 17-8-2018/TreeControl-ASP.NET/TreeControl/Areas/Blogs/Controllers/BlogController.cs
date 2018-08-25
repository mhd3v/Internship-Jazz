using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreeControl.Areas.Blogs.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blogs/Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}