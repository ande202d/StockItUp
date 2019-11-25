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
    public class StoreProductsController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/StoreProducts
        public IQueryable<StoreProduct> GetStoreProducts()
        {
            return db.StoreProducts;
        }

        // GET: api/StoreProducts/5
        [ResponseType(typeof(StoreProduct))]
        public IHttpActionResult GetStoreProduct(int id)
        {
            StoreProduct storeProduct = db.StoreProducts.Find(id);
            if (storeProduct == null)
            {
                return NotFound();
            }

            return Ok(storeProduct);
        }

        // PUT: api/StoreProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStoreProduct(int id, StoreProduct storeProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != storeProduct.Id)
            {
                return BadRequest();
            }

            db.Entry(storeProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreProductExists(id))
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

        // POST: api/StoreProducts
        [ResponseType(typeof(StoreProduct))]
        public IHttpActionResult PostStoreProduct(StoreProduct storeProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StoreProducts.Add(storeProduct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = storeProduct.Id }, storeProduct);
        }

        // DELETE: api/StoreProducts/5
        [ResponseType(typeof(StoreProduct))]
        public IHttpActionResult DeleteStoreProduct(int id)
        {
            StoreProduct storeProduct = db.StoreProducts.Find(id);
            if (storeProduct == null)
            {
                return NotFound();
            }

            db.StoreProducts.Remove(storeProduct);
            db.SaveChanges();

            return Ok(storeProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreProductExists(int id)
        {
            return db.StoreProducts.Count(e => e.Id == id) > 0;
        }
    }
}