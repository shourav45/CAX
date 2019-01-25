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
    public class PartyInfoesController : ApiController
    {
        private dbcontext db = new dbcontext();

        // GET: api/PartyInfoes
        public IQueryable<PartyInfo> GetPartyInfoset()
        {
            return db.PartyInfoset;
        }

        // GET: api/PartyInfoes/5
        [ResponseType(typeof(PartyInfo))]
        public IHttpActionResult GetPartyInfo(int id)
        {
            PartyInfo partyInfo = db.PartyInfoset.Find(id);
            if (partyInfo == null)
            {
                return NotFound();
            }

            return Ok(partyInfo);
        }

        // PUT: api/PartyInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartyInfo(int id, PartyInfo partyInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partyInfo.PartyInfoId)
            {
                return BadRequest();
            }

            db.Entry(partyInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyInfoExists(id))
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

        // POST: api/PartyInfoes
        [ResponseType(typeof(PartyInfo))]
        public IHttpActionResult PostPartyInfo(PartyInfo partyInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PartyInfoset.Add(partyInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partyInfo.PartyInfoId }, partyInfo);
        }

        // DELETE: api/PartyInfoes/5
        [ResponseType(typeof(PartyInfo))]
        public IHttpActionResult DeletePartyInfo(int id)
        {
            PartyInfo partyInfo = db.PartyInfoset.Find(id);
            if (partyInfo == null)
            {
                return NotFound();
            }

            db.PartyInfoset.Remove(partyInfo);
            db.SaveChanges();

            return Ok(partyInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartyInfoExists(int id)
        {
            return db.PartyInfoset.Count(e => e.PartyInfoId == id) > 0;
        }
    }
}