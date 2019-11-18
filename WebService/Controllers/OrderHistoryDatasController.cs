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
    public class OrderHistoryDatasController : ApiController
    {
        private StockItUpDBContext db = new StockItUpDBContext();

        // GET: api/OrderHistoryDatas
        public IQueryable<OrderHistoryData> GetOrderHistoryDatas()
        {
            return db.OrderHistoryDatas;
        }

        // GET: api/OrderHistoryDatas/5
        [ResponseType(typeof(OrderHistoryData))]
        public IHttpActionResult GetOrderHistoryData(int id)
        {
            OrderHistoryData orderHistoryData = db.OrderHistoryDatas.Find(id);
            if (orderHistoryData == null)
            {
                return NotFound();
            }

            return Ok(orderHistoryData);
        }

        // PUT: api/OrderHistoryDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderHistoryData(int id, OrderHistoryData orderHistoryData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderHistoryData.Id)
            {
                return BadRequest();
            }

            db.Entry(orderHistoryData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderHistoryDataExists(id))
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

        // POST: api/OrderHistoryDatas
        [ResponseType(typeof(OrderHistoryData))]
        public IHttpActionResult PostOrderHistoryData(OrderHistoryData orderHistoryData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderHistoryDatas.Add(orderHistoryData);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OrderHistoryDataExists(orderHistoryData.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = orderHistoryData.Id }, orderHistoryData);
        }

        // DELETE: api/OrderHistoryDatas/5
        [ResponseType(typeof(OrderHistoryData))]
        public IHttpActionResult DeleteOrderHistoryData(int id)
        {
            OrderHistoryData orderHistoryData = db.OrderHistoryDatas.Find(id);
            if (orderHistoryData == null)
            {
                return NotFound();
            }

            db.OrderHistoryDatas.Remove(orderHistoryData);
            db.SaveChanges();

            return Ok(orderHistoryData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderHistoryDataExists(int id)
        {
            return db.OrderHistoryDatas.Count(e => e.Id == id) > 0;
        }
    }
}