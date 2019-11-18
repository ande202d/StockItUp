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
    public class InventoryCountsController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/InventoryCounts
        public IQueryable<InventoryCount> GetInventoryCounts()
        {
            return db.InventoryCounts;
        }

        // GET: api/InventoryCounts/5
        [ResponseType(typeof(InventoryCount))]
        public IHttpActionResult GetInventoryCount(int id)
        {
            InventoryCount inventoryCount = db.InventoryCounts.Find(id);
            if (inventoryCount == null)
            {
                return NotFound();
            }

            return Ok(inventoryCount);
        }

        // PUT: api/InventoryCounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventoryCount(int id, InventoryCount inventoryCount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryCount.Id)
            {
                return BadRequest();
            }

            db.Entry(inventoryCount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryCountExists(id))
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

        // POST: api/InventoryCounts
        [ResponseType(typeof(InventoryCount))]
        public IHttpActionResult PostInventoryCount(InventoryCount inventoryCount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryCounts.Add(inventoryCount);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventoryCount.Id }, inventoryCount);
        }

        // DELETE: api/InventoryCounts/5
        [ResponseType(typeof(InventoryCount))]
        public IHttpActionResult DeleteInventoryCount(int id)
        {
            InventoryCount inventoryCount = db.InventoryCounts.Find(id);
            if (inventoryCount == null)
            {
                return NotFound();
            }

            db.InventoryCounts.Remove(inventoryCount);
            db.SaveChanges();

            return Ok(inventoryCount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryCountExists(int id)
        {
            return db.InventoryCounts.Count(e => e.Id == id) > 0;
        }
    }
}