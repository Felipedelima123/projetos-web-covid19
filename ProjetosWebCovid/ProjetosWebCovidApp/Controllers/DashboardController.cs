using ProjetosWebCovidApp.DAL;
using ProjetosWebCovidApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace ProjetosWebCovidApp.Controllers
{
    public class DashboardController : Controller
    {
        private CovidTrackerContext db = new CovidTrackerContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                var Username = Session["Username"].ToString();
                var User = db.Users.FirstOrDefault(s => s.Username == Username);

                if (User != null)
                {
                    var positionsQuery = db.UserPositions.Where(p => p.UserId == User.ID);
                    var positions = positionsQuery.ToList();
                    ViewBag.positions = positions;
                }

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}