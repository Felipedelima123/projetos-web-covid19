using ProjetosWebCovidApp.DAL;
using ProjetosWebCovidApp.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace ProjetosWebCovidApp.Controllers
{
    public class HomeController : Controller
    {
        private CovidTrackerContext db = new CovidTrackerContext();
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Username == _user.Username);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = db.Users.Where(s => s.Username.Equals(username) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Username"] = data.FirstOrDefault().Username;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["ID"] = data.FirstOrDefault().ID;
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login", "Home");
                }
            }
            return View();
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}