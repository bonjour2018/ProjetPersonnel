using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApiLoginLogout.Models;

namespace WebApiLoginLogout.Controllers
{
    [EnableCorsAttribute("http://localhost:4200", "*", "*")]
    public class AnnoncesController : ApiController
    {
        private AnnonceDbContext db = new AnnonceDbContext();
        private ApplicationUserDbContext db1 = new ApplicationUserDbContext();

        // GET: api/Annonces
        [Authorize]
        public IQueryable<Annonce> GetAnnonces()
        {
            return db.Annonces;
        }

        // GET: api/Annonces/5
        [ResponseType(typeof(Annonce))]
        [Authorize]
        public IHttpActionResult GetAnnonce(int id)
        {
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return NotFound();
            }

            return Ok(annonce);
        }

        // PUT: api/Annonces/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnnonce(int id, Annonce annonce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != annonce.Id)
            {
                return BadRequest();
            }

            db.Entry(annonce).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnonceExists(id))
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

        // POST: api/Annonces
        [Route("api/Annonces/PostAnnonce")]
        [ResponseType(typeof(Annonce))]
        [Authorize]
        public /*IHttpActionResult*/ Annonce PostAnnonce(AnnonceModel annonce)
        {
           // int max = 0;
            if (!ModelState.IsValid)
            {
                return null;// BadRequest(ModelState);
            }
            int max = db.Annonces.Count();
            Annonce annonceAjoutee = new Annonce();
            //annonceAjoutee.Id = max + 1;
            annonceAjoutee.UserId = db1.Users.FirstOrDefault(p => p.UserName == annonce.UserName).Id;
            annonceAjoutee.UserName = annonce.UserName;
            annonceAjoutee.ContenuAnnonce = annonce.ContenuAnnonce;
            annonceAjoutee.DateAnnonce = DateTime.Now;
            db.Annonces.Add(annonceAjoutee);
            try
            {
                db.SaveChanges();
                //annonceAjoutee.Id=db.Annonces.Last().Id;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

            return annonceAjoutee;// CreatedAtRoute("DefaultApi", new { id = annonceAjoutee.Id }, annonceAjoutee);
        }

        // DELETE: api/Annonces/5
        [ResponseType(typeof(Annonce))]
        public IHttpActionResult DeleteAnnonce(int id)
        {
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return NotFound();
            }

            db.Annonces.Remove(annonce);
            db.SaveChanges();

            return Ok(annonce);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnonceExists(int id)
        {
            return db.Annonces.Count(e => e.Id == id) > 0;
        }
    }
}