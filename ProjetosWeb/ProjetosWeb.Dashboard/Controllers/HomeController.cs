using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetosWeb.Dashboard.Filters;

namespace Dashboard.Controllers
{   
    [FiltroExcessao]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ActionFilter()
        {
            throw new NotImplementedException();
        }
    }
}