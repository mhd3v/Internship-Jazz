using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreeControl.Areas.Forums.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forums/Forum
        public ActionResult Index()
        {
            return View();
        }
    }
}