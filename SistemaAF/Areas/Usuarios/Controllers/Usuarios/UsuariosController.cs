using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaAF.Areas.Usuarios.Models;

namespace Template.Areas.Usuarios.Controllers
{
    public class UsuariosController : ApiController
    {
        private UsuariosEntities db = new UsuariosEntities();

        // GET: api/Usuarios
        public IQueryable<SistemaAF.Areas.Usuarios.Models.Usuarios> GetUsuarios()
        {
            

            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(SistemaAF.Areas.Usuarios.Models.Usuarios))]
        public async Task<IHttpActionResult> GetUsuarios(int id)
        {
            SistemaAF.Areas.Usuarios.Models.Usuarios usuarios = await db.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuarios(int id, SistemaAF.Areas.Usuarios.Models.Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Id)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(SistemaAF.Areas.Usuarios.Models.Usuarios))]
        public async Task<IHttpActionResult> PostUsuarios(SistemaAF.Areas.Usuarios.Models.Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.AddOrUpdate(usuarios);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuarios.Id }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(SistemaAF.Areas.Usuarios.Models.Usuarios))]
        public async Task<IHttpActionResult> DeleteUsuarios(int id)
        {
            SistemaAF.Areas.Usuarios.Models.Usuarios usuarios = await db.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
            await db.SaveChangesAsync();

            return Ok(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuariosExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}