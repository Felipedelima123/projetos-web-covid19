using ProjetosWebCovidApp.DAL;
using ProjetosWebCovidApp.Models;
using System.Collections.Generic;
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

                    // get user positions for timeline
                    var positionsQuery = db.UserPositions.Where(p => p.UserId == User.ID);
                    var positions = positionsQuery.ToList();
                    ViewBag.positions = positions;


                    // get stats by neighborhood to show in the map
                    var neighborhoodsQuery = db.Neighborhoods.Where(n => n.Geometry != null);
                    var neighborhoods = neighborhoodsQuery.ToList();
                    ViewBag.neighborhoods = neighborhoods;


                    List<NeighborhoodInfecteds> InfectedStats = new List<NeighborhoodInfecteds>();

                    if (neighborhoods.Count() > 0)
                    {
                        foreach (Neighborhood neighborhood in neighborhoods)
                        {
                            var infectedDatasQuery = db.InfectedDatas.Where(i => i.Bairro.Equals(neighborhood.Name));
                            if (infectedDatasQuery.Count() > 0)
                            {
                                InfectedStats.Add(new NeighborhoodInfecteds(neighborhood, infectedDatasQuery.ToList()));
                            }
                        }
                    }


                    ViewBag.InfectedStats = InfectedStats;
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