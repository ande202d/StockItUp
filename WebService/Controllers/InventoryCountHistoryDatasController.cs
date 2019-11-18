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
    public class InventoryCountHistoryDatasController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/InventoryCountHistoryDatas
        public IQueryable<InventoryCountHistoryData> GetInventoryCountHistoryDatas()
        {
            return db.InventoryCountHistoryDatas;
        }

        // GET: api/InventoryCountHistoryDatas/5
        [ResponseType(typeof(InventoryCountHistoryData))]
        public IHttpActionResult GetInventoryCountHistoryData(int id)
        {
            InventoryCountHistoryData inventoryCountHistoryData = db.InventoryCountHistoryDatas.Find(id);
            if (inventoryCountHistoryData == null)
            {
                return NotFound();
            }

            return Ok(inventoryCountHistoryData);
        }

        // PUT: api/InventoryCountHistoryDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventoryCountHistoryData(int id, InventoryCountHistoryData inventoryCountHistoryData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryCountHistoryData.Id)
            {
                return BadRequest();
            }

            db.Entry(inventoryCountHistoryData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryCountHistoryDataExists(id))
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

        // POST: api/InventoryCountHistoryDatas
        [ResponseType(typeof(InventoryCountHistoryData))]
        public IHttpActionResult PostInventoryCountHistoryData(InventoryCountHistoryData inventoryCountHistoryData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryCountHistoryDatas.Add(inventoryCountHistoryData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InventoryCountHistoryDataExists(inventoryCountHistoryData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inventoryCountHistoryData.Id }, inventoryCountHistoryData);
        }

        // DELETE: api/InventoryCountHistoryDatas/5
        [ResponseType(typeof(InventoryCountHistoryData))]
        public IHttpActionResult DeleteInventoryCountHistoryData(int id)
        {
            InventoryCountHistoryData inventoryCountHistoryData = db.InventoryCountHistoryDatas.Find(id);
            if (inventoryCountHistoryData == null)
            {
                return NotFound();
            }

            db.InventoryCountHistoryDatas.Remove(inventoryCountHistoryData);
            db.SaveChanges();

            return Ok(inventoryCountHistoryData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryCountHistoryDataExists(int id)
        {
            return db.InventoryCountHistoryDatas.Count(e => e.Id == id) > 0;
        }
    }
}