using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atlas.WebApp.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Status()
        {
            return PartialView("_Status");
        }
        public ActionResult About()
        {
            return PartialView("_About");
        }
        public ActionResult Contact()
        {
            return PartialView("_Contact");
        }
        public ActionResult Home()
        {
            return PartialView("_Home");
        }
    }
}