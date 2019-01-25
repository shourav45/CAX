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
using WebApi.Models;

namespace WebApi.ApiControllers
{
    public class SPOInfoesController : ApiController
    {
        private dbcontext db = new dbcontext();

        // GET: api/SPOInfoes
        public IQueryable<SPOInfo> GetSPOInfoset()
        {
            return db.SPOInfoset;
        }

        // GET: api/SPOInfoes/5
        [ResponseType(typeof(SPOInfo))]
        public IHttpActionResult GetSPOInfo(int id)
        {
            SPOInfo sPOInfo = db.SPOInfoset.Find(id);
            if (sPOInfo == null)
            {
                return NotFound();
            }

            return Ok(sPOInfo);
        }

        // PUT: api/SPOInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSPOInfo(int id, SPOInfo sPOInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sPOInfo.SPOInfoId)
            {
                return BadRequest();
            }

            db.Entry(sPOInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SPOInfoExists(id))
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

        // POST: api/SPOInfoes
        [ResponseType(typeof(SPOInfo))]
        public IHttpActionResult PostSPOInfo(SPOInfo sPOInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SPOInfoset.Add(sPOInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sPOInfo.SPOInfoId }, sPOInfo);
        }

        // DELETE: api/SPOInfoes/5
        [ResponseType(typeof(SPOInfo))]
        public IHttpActionResult DeleteSPOInfo(int id)
        {
            SPOInfo sPOInfo = db.SPOInfoset.Find(id);
            if (sPOInfo == null)
            {
                return NotFound();
            }

            db.SPOInfoset.Remove(sPOInfo);
            db.SaveChanges();

            return Ok(sPOInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SPOInfoExists(int id)
        {
            return db.SPOInfoset.Count(e => e.SPOInfoId == id) > 0;
        }
    }
}