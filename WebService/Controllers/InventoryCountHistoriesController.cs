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
    public class InventoryCountHistoriesController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/InventoryCountHistories
        public IQueryable<InventoryCountHistory> GetInventoryCountHistories()
        {
            return db.InventoryCountHistories;
        }

        // GET: api/InventoryCountHistories/5
        [ResponseType(typeof(InventoryCountHistory))]
        public IHttpActionResult GetInventoryCountHistory(int id)
        {
            InventoryCountHistory inventoryCountHistory = db.InventoryCountHistories.Find(id);
            if (inventoryCountHistory == null)
            {
                return NotFound();
            }

            return Ok(inventoryCountHistory);
        }

        // PUT: api/InventoryCountHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventoryCountHistory(int id, InventoryCountHistory inventoryCountHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryCountHistory.Id)
            {
                return BadRequest();
            }

            db.Entry(inventoryCountHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryCountHistoryExists(id))
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

        // POST: api/InventoryCountHistories
        [ResponseType(typeof(InventoryCountHistory))]
        public IHttpActionResult PostInventoryCountHistory(InventoryCountHistory inventoryCountHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryCountHistories.Add(inventoryCountHistory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InventoryCountHistoryExists(inventoryCountHistory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inventoryCountHistory.Id }, inventoryCountHistory);
        }

        // DELETE: api/InventoryCountHistories/5
        [ResponseType(typeof(InventoryCountHistory))]
        public IHttpActionResult DeleteInventoryCountHistory(int id)
        {
            InventoryCountHistory inventoryCountHistory = db.InventoryCountHistories.Find(id);
            if (inventoryCountHistory == null)
            {
                return NotFound();
            }

            db.InventoryCountHistories.Remove(inventoryCountHistory);
            db.SaveChanges();

            return Ok(inventoryCountHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryCountHistoryExists(int id)
        {
            return db.InventoryCountHistories.Count(e => e.Id == id) > 0;
        }
    }
}