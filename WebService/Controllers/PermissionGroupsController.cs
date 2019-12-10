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
    public class PermissionGroupsController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/PermissionGroups
        public IQueryable<PermissionGroup> GetPermissionGroups()
        {
            return db.PermissionGroups;
        }

        // GET: api/PermissionGroups/5
        [ResponseType(typeof(PermissionGroup))]
        public IHttpActionResult GetPermissionGroup(int id)
        {
            PermissionGroup permissionGroup = db.PermissionGroups.Find(id);
            if (permissionGroup == null)
            {
                return NotFound();
            }

            return Ok(permissionGroup);
        }

        // PUT: api/PermissionGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPermissionGroup(int id, PermissionGroup permissionGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permissionGroup.Id)
            {
                return BadRequest();
            }

            db.Entry(permissionGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionGroupExists(id))
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

        // POST: api/PermissionGroups
        [ResponseType(typeof(PermissionGroup))]
        public IHttpActionResult PostPermissionGroup(PermissionGroup permissionGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PermissionGroups.Add(permissionGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permissionGroup.Id }, permissionGroup);
        }

        // DELETE: api/PermissionGroups/5
        [ResponseType(typeof(PermissionGroup))]
        public IHttpActionResult DeletePermissionGroup(int id)
        {
            PermissionGroup permissionGroup = db.PermissionGroups.Find(id);
            if (permissionGroup == null)
            {
                return NotFound();
            }

            db.PermissionGroups.Remove(permissionGroup);
            db.SaveChanges();

            return Ok(permissionGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermissionGroupExists(int id)
        {
            return db.PermissionGroups.Count(e => e.Id == id) > 0;
        }
    }
}