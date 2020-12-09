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
    public class UserPositionsApiController : ApiController
    {
        private CovidTrackerContext db = new CovidTrackerContext();

        // GET: api/UserPositionsApi
        public IQueryable<UserPosition> GetUserPositions()
        {
            return db.UserPositions;
        }

        // GET: api/UserPositionsApi/5
        [ResponseType(typeof(UserPosition))]
        public IHttpActionResult GetUserPosition(int id)
        {
            UserPosition userPosition = db.UserPositions.Find(id);
            if (userPosition == null)
            {
                return NotFound();
            }

            return Ok(userPosition);
        }

        // PUT: api/UserPositionsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserPosition(int id, UserPosition userPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userPosition.ID)
            {
                return BadRequest();
            }

            db.Entry(userPosition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPositionExists(id))
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

        // POST: api/UserPositionsApi
        [ResponseType(typeof(UserPosition))]
        public IHttpActionResult PostUserPosition(UserPosition userPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.UserPositions.Add(userPosition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userPosition.ID }, userPosition);
        }

        // DELETE: api/UserPositionsApi/5
        [ResponseType(typeof(UserPosition))]
        public IHttpActionResult DeleteUserPosition(int id)
        {
            UserPosition userPosition = db.UserPositions.Find(id);
            if (userPosition == null)
            {
                return NotFound();
            }

            db.UserPositions.Remove(userPosition);
            db.SaveChanges();

            return Ok(userPosition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserPositionExists(int id)
        {
            return db.UserPositions.Count(e => e.ID == id) > 0;
        }
    }
}