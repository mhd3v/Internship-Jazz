using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TreeControl.Models;

namespace TreeControl.Controllers
{
    public class TreeController : Controller
    {
        // GET: Tree
        public ActionResult Index()
        {
            List<Node> childrenList = new List<Node>()
            {
                new Node(){title = "Child 1" },
                new Node(){title = "Child 2" },
                new Node(){title = "Child 3" },
            };

            List<Node> parentsList = new List<Node>()
            {
                new Node()
                {
                    title = "Parent 1",
                    folder = true,
                    key = 1,
                    children = childrenList
                },

                new Node()
                {
                    title = "Parent 2",
                    folder = true,
                    key = 1,
                    children = childrenList
                }
            };

            return View(parentsList);
        }

        [HttpPost]
        public ActionResult GetSelectedNodes(string[] selectedNodesTitles)
        {
            if (selectedNodesTitles.Length == 0)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            List<Node> selectedNodes = new List<Node>();

            foreach(string title in selectedNodesTitles)
            {
                selectedNodes.Add(new Node() { title = title});
            }

            if (selectedNodes.Count == 1)
            {
                if (selectedNodes[0].title == "Parent 1")
                {
                    var redirectUrl = new UrlHelper(Request.RequestContext).Action("Autofill", "Tree");
                    return Json(new { success = true, selectedNodes = selectedNodes, url = redirectUrl }, JsonRequestBehavior.AllowGet);
                }

            }
          
            return Json(new { success = true, selectedNodes = selectedNodes }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult CheckForm()
        {
            string pageName = Request.Form["page-name"];

            if (pageName.Equals("autofill"))
                return RedirectToAction("Autofill");
            else
                return RedirectToAction("Index");

        }

        public ActionResult Autofill()
        {
            return View();
        }

    }
}