using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ProjetosWeb.Dashboard.api;
using ProjetosWeb.Dashboard.Models;

namespace ProjetosWeb.Dashboard.Controllers
{
    public class SignInController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login(User user)
        {
            APIHttpClient clientHttp = new APIHttpClient("http://localhost:58441/api/");
            var loginId = clientHttp.Post<User>("SignIn", user);

            return Redirect("/Home/Dashboard");
        }

        public ActionResult Recovery()
        {
            return View();
        }
    }
}