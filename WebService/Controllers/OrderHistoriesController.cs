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
    public class OrderHistoriesController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/OrderHistories
        public IQueryable<OrderHistory> GetOrderHistories()
        {
            return db.OrderHistories;
        }

        // GET: api/OrderHistories/5
        [ResponseType(typeof(OrderHistory))]
        public IHttpActionResult GetOrderHistory(int id)
        {
            OrderHistory orderHistory = db.OrderHistories.Find(id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            return Ok(orderHistory);
        }

        // PUT: api/OrderHistories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderHistory(int id, OrderHistory orderHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderHistory.Id)
            {
                return BadRequest();
            }

            db.Entry(orderHistory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderHistoryExists(id))
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

        // POST: api/OrderHistories
        [ResponseType(typeof(OrderHistory))]
        public IHttpActionResult PostOrderHistory(OrderHistory orderHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderHistories.Add(orderHistory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderHistoryExists(orderHistory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderHistory.Id }, orderHistory);
        }

        // DELETE: api/OrderHistories/5
        [ResponseType(typeof(OrderHistory))]
        public IHttpActionResult DeleteOrderHistory(int id)
        {
            OrderHistory orderHistory = db.OrderHistories.Find(id);
            if (orderHistory == null)
            {
                return NotFound();
            }

            db.OrderHistories.Remove(orderHistory);
            db.SaveChanges();

            return Ok(orderHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderHistoryExists(int id)
        {
            return db.OrderHistories.Count(e => e.Id == id) > 0;
        }
    }
}