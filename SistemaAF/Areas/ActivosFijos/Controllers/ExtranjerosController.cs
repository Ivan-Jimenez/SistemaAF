using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using SistemaAF.Areas.ActivosFijos.Models;

namespace SistemaAF.Areas.ActivosFijos.Controllers
{
    public class ExtranjerosController : ApiController
    {
        private ActivosFijosEntities db = new ActivosFijosEntities();
   
        // GET: api/Extranjeros
        public IQueryable<Extranjeros> GetExtranjeros()
        {
            return db.Extranjeros;
        }

        // GET: api/Extranjeros/5
        [ResponseType(typeof(Extranjeros))]
        public IHttpActionResult GetExtranjeros(string id)
        {
            Extranjeros extranjeros = db.Extranjeros.Find(id);
            if (extranjeros == null)
            {
                return NotFound();
            }

            return Ok(extranjeros);
        }

        // PUT: api/Extranjeros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExtranjeros(string id, Extranjeros extranjeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != extranjeros.NoParte)
            {
                return BadRequest();
            }

            db.Entry(extranjeros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtranjerosExists(id))
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

        // POST: api/Extranjeros
        [ResponseType(typeof(Extranjeros))]
        public IHttpActionResult PostExtranjeros(Extranjeros extranjeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Extranjeros.Add(extranjeros);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExtranjerosExists(extranjeros.NoParte))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = extranjeros.NoParte }, extranjeros);
        }

        // DELETE: api/Extranjeros/5
        [ResponseType(typeof(Extranjeros))]
        public IHttpActionResult DeleteExtranjeros(string id)
        {
            Extranjeros extranjeros = db.Extranjeros.Find(id);
            if (extranjeros == null)
            {
                return NotFound();
            }

            db.Extranjeros.Remove(extranjeros);
            db.SaveChanges();

            return Ok(extranjeros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExtranjerosExists(string id)
        {
            return db.Extranjeros.Count(e => e.NoParte == id) > 0;
        }
    }
}