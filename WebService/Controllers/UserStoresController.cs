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
using WebService;

namespace WebService.Controllers
{
    public class UserStoresController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/UserStores
        public IQueryable<UserStore> GetUserStores()
        {
            return db.UserStores;
        }

        // GET: api/UserStores/5
        [ResponseType(typeof(UserStore))]
        public IHttpActionResult GetUserStore(int id)
        {
            UserStore userStore = db.UserStores.Find(id);
            if (userStore == null)
            {
                return NotFound();
            }

            return Ok(userStore);
        }

        // PUT: api/UserStores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserStore(int id, UserStore userStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userStore.Id)
            {
                return BadRequest();
            }

            db.Entry(userStore).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStoreExists(id))
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

        // POST: api/UserStores
        [ResponseType(typeof(UserStore))]
        public IHttpActionResult PostUserStore(UserStore userStore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserStores.Add(userStore);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userStore.Id }, userStore);
        }

        // DELETE: api/UserStores/5
        [ResponseType(typeof(UserStore))]
        public IHttpActionResult DeleteUserStore(int id)
        {
            UserStore userStore = db.UserStores.Find(id);
            if (userStore == null)
            {
                return NotFound();
            }

            db.UserStores.Remove(userStore);
            db.SaveChanges();

            return Ok(userStore);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserStoreExists(int id)
        {
            return db.UserStores.Count(e => e.Id == id) > 0;
        }
    }
}