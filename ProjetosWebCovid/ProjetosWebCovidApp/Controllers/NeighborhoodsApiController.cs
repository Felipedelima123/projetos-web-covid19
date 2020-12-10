using ProjetosWebCovidApp.DAL;
using ProjetosWebCovidApp.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProjetosWebCovidApp.Controllers
{
    public class NeighborhoodsApiController : ApiController
    {
        private CovidTrackerContext db = new CovidTrackerContext();

        // GET: api/NeighborhoodsApi
        public IQueryable<Neighborhood> GetNeighborhoods()
        {
            return db.Neighborhoods;
        }

        // GET: api/NeighborhoodsApi/5
        [ResponseType(typeof(Neighborhood))]
        public IHttpActionResult GetNeighborhood(int id)
        {
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            return Ok(neighborhood);
        }

        // PUT: api/NeighborhoodsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNeighborhood(int id, Neighborhood neighborhood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != neighborhood.ID)
            {
                return BadRequest();
            }

            db.Entry(neighborhood).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeighborhoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NeighborhoodsApi
        [ResponseType(typeof(Neighborhood))]
        public IHttpActionResult PostNeighborhood(Neighborhood neighborhood)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Neighborhoods.Add(neighborhood);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = neighborhood.ID }, neighborhood);
        }

        // DELETE: api/NeighborhoodsApi/5
        [ResponseType(typeof(Neighborhood))]
        public IHttpActionResult DeleteNeighborhood(int id)
        {
            Neighborhood neighborhood = db.Neighborhoods.Find(id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            db.Neighborhoods.Remove(neighborhood);
            db.SaveChanges();

            return Ok(neighborhood);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NeighborhoodExists(int id)
        {
            return db.Neighborhoods.Count(e => e.ID == id) > 0;
        }
    }
}