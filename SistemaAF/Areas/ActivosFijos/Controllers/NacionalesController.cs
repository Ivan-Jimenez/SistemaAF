using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaAF.Areas.ActivosFijos.Models;

namespace SistemaAF.Areas.ActivosFijos.Controllers
{
    public class NacionalesController : ApiController
    {
        private ActivosFijosEntities db = new ActivosFijosEntities();

        // GET: api/Nacionales
        public IQueryable<Nacionales> GetNacionales()
        {
            return db.Nacionales;
        }

        // GET: api/Nacionales/5
        [ResponseType(typeof(Nacionales))]
        public IHttpActionResult GetNacionales(string id)
        {
            Nacionales nacionales = db.Nacionales.Find(id);
            if (nacionales == null)
            {
                return NotFound();
            }

            return Ok(nacionales);
        }

        // PUT: api/Nacionales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNacionales(string id, Nacionales nacionales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nacionales.NoActivo)
            {
                return BadRequest();
            }

            db.Entry(nacionales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NacionalesExists(id))
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

       // POST: api/Nacionales
       [ResponseType(typeof(Nacionales))]
        public IHttpActionResult PostNacionales(Nacionales nacionales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nacionales.Add(nacionales);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NacionalesExists(nacionales.NoActivo))
                {
                    return Conflict();
                    //db.Nacionales.Remove(nacionales);
                    //db.Nacionales.Add(nacionales);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nacionales.NoActivo }, nacionales);
        }

        // DELETE: api/Nacionales/5
        [ResponseType(typeof(Nacionales))]
        public IHttpActionResult DeleteNacionales(string id)
        {
            Nacionales nacionales = db.Nacionales.Find(id);
            if (nacionales == null)
            {
                return NotFound();
            }

            db.Nacionales.Remove(nacionales);
            db.SaveChanges();

            return Ok(nacionales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NacionalesExists(string id)
        {
            return db.Nacionales.Count(e => e.NoActivo == id) > 0;
        }
    }
}