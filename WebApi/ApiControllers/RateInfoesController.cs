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
    public class RateInfoesController : ApiController
    {
        private dbcontext db = new dbcontext();

        // GET: api/RateInfoes
        public IQueryable<RateInfo> GetRateInfoset()
        {
            List<RateInfo> RateList = db.RateInfoset.ToList();
            //List<PartyInfo> PartyList = db.PartyInfoset.ToList();
            //var rate = from rt in db.RateInfoset.ToList().Where(r => r.PartyInfoId == PartyList.par)
            foreach (var rate in RateList)
            {
                PartyInfo Party = db.PartyInfoset.Where(p => p.PartyInfoId.ToString() == rate.PartyInfoId).FirstOrDefault();
                rate.PartyInfoId = Party.Name;
            }
            return RateList.AsQueryable();
        }

        // GET: api/RateInfoes/5
        [ResponseType(typeof(RateInfo))]
        public IHttpActionResult GetRateInfo(int id)
        {
            RateInfo rateInfo = db.RateInfoset.Find(id);
            if (rateInfo == null)
            {
                return NotFound();
            }

            return Ok(rateInfo);
        }

        // PUT: api/RateInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRateInfo(int id, RateInfo rateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rateInfo.RateInfoId)
            {
                return BadRequest();
            }

            db.Entry(rateInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateInfoExists(id))
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

        // POST: api/RateInfoes
        [ResponseType(typeof(RateInfo))]
        public IHttpActionResult PostRateInfo(RateInfo rateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RateInfoset.Add(rateInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rateInfo.RateInfoId }, rateInfo);
        }

        // DELETE: api/RateInfoes/5
        [ResponseType(typeof(RateInfo))]
        public IHttpActionResult DeleteRateInfo(int id)
        {
            RateInfo rateInfo = db.RateInfoset.Find(id);
            if (rateInfo == null)
            {
                return NotFound();
            }

            db.RateInfoset.Remove(rateInfo);
            db.SaveChanges();

            return Ok(rateInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RateInfoExists(int id)
        {
            return db.RateInfoset.Count(e => e.RateInfoId == id) > 0;
        }
    }
}