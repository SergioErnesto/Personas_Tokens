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
using Practica_token.Models;

namespace Practica_token.Controllers
{
    public class practica_tokenController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/practica_token
        [Authorize]
        public IQueryable<practica_token> Getpractica_token()
        {
            return db.practica_token;
        }

        // GET: api/practica_token/5
        [Authorize]
        [ResponseType(typeof(practica_token))]
        public IHttpActionResult Getpractica_token(int id)
        {
            practica_token practica_token = db.practica_token.Find(id);
            if (practica_token == null)
            {
                return NotFound();
            }

            return Ok(practica_token);
        }

        // PUT: api/practica_token/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpractica_token(int id, practica_token practica_token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != practica_token.PersonId)
            {
                return BadRequest();
            }

            db.Entry(practica_token).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!practica_tokenExists(id))
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

        // POST: api/practica_token
        [Authorize]
        [ResponseType(typeof(practica_token))]
        public IHttpActionResult Postpractica_token(practica_token practica_token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.practica_token.Add(practica_token);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = practica_token.PersonId }, practica_token);
        }

        // DELETE: api/practica_token/5
        [Authorize]
        [ResponseType(typeof(practica_token))]
        public IHttpActionResult Deletepractica_token(int id)
        {
            practica_token practica_token = db.practica_token.Find(id);
            if (practica_token == null)
            {
                return NotFound();
            }

            db.practica_token.Remove(practica_token);
            db.SaveChanges();

            return Ok(practica_token);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool practica_tokenExists(int id)
        {
            return db.practica_token.Count(e => e.PersonId == id) > 0;
        }
    }
}