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
    public class InventoryCountProductsController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/InventoryCountProducts
        public IQueryable<InventoryCountProduct> GetInventoryCountProducts()
        {
            return db.InventoryCountProducts;
        }

        // GET: api/InventoryCountProducts/5
        [ResponseType(typeof(InventoryCountProduct))]
        public IHttpActionResult GetInventoryCountProduct(int id)
        {
            InventoryCountProduct inventoryCountProduct = db.InventoryCountProducts.Find(id);
            if (inventoryCountProduct == null)
            {
                return NotFound();
            }

            return Ok(inventoryCountProduct);
        }

        // PUT: api/InventoryCountProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventoryCountProduct(int id, InventoryCountProduct inventoryCountProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventoryCountProduct.InventoryCount)
            {
                return BadRequest();
            }

            db.Entry(inventoryCountProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryCountProductExists(id))
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

        // POST: api/InventoryCountProducts
        [ResponseType(typeof(InventoryCountProduct))]
        public IHttpActionResult PostInventoryCountProduct(InventoryCountProduct inventoryCountProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InventoryCountProducts.Add(inventoryCountProduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InventoryCountProductExists(inventoryCountProduct.InventoryCount))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inventoryCountProduct.InventoryCount }, inventoryCountProduct);
        }

        // DELETE: api/InventoryCountProducts/5
        [ResponseType(typeof(InventoryCountProduct))]
        public IHttpActionResult DeleteInventoryCountProduct(int id)
        {
            InventoryCountProduct inventoryCountProduct = db.InventoryCountProducts.Find(id);
            if (inventoryCountProduct == null)
            {
                return NotFound();
            }

            db.InventoryCountProducts.Remove(inventoryCountProduct);
            db.SaveChanges();

            return Ok(inventoryCountProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryCountProductExists(int id)
        {
            return db.InventoryCountProducts.Count(e => e.InventoryCount == id) > 0;
        }
    }
}