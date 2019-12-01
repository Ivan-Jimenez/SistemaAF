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
using SistemaAF.Areas.ActivosFijos.Models;

namespace SistemaAF.Areas.ActivosFijos.Controllers
{
    public class NacionalDocumentsController : ApiController
    {
        private ActivosFijosEntities db = new ActivosFijosEntities();

        // GET: api/NacionalDocuments
        public IQueryable<object> GetNacionalDocument(string no_asset, string type)
        {
            var documents = from document in db.NacionalDocument
                            where document.NoAsset == no_asset && document.DocumentType == type
                            select new
                            {
                                DocumentType = document.DocumentType,
                                DocumentName = document.DocumentName,
                            };
            return documents;
        }

        // GET: api/NacionalDocuments/5
        [ResponseType(typeof(NacionalDocument))]
        public IHttpActionResult GetNacionalDocument(int id)
        {
            NacionalDocument nacionalDocument = db.NacionalDocument.Find(id);
            if (nacionalDocument == null)
            {
                return NotFound();
            }

            return Ok(nacionalDocument);
        }

        // PUT: api/NacionalDocuments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNacionalDocument(int id, NacionalDocument nacionalDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nacionalDocument.ID)
            {
                return BadRequest();
            }

            db.Entry(nacionalDocument).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NacionalDocumentExists(id))
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

        // POST: api/NacionalDocuments
        [ResponseType(typeof(NacionalDocument))]
        public IHttpActionResult PostNacionalDocument(NacionalDocument nacionalDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NacionalDocument.Add(nacionalDocument);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nacionalDocument.ID }, nacionalDocument);
        }

        // DELETE: api/NacionalDocuments/5
        [ResponseType(typeof(NacionalDocument))]
        public IHttpActionResult DeleteNacionalDocument(int id)
        {
            NacionalDocument nacionalDocument = db.NacionalDocument.Find(id);
            if (nacionalDocument == null)
            {
                return NotFound();
            }

            db.NacionalDocument.Remove(nacionalDocument);
            db.SaveChanges();

            return Ok(nacionalDocument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NacionalDocumentExists(int id)
        {
            return db.NacionalDocument.Count(e => e.ID == id) > 0;
        }
    }
}