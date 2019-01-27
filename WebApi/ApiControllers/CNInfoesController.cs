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
    public class CNInfoesController : ApiController
    {
        private dbcontext db = new dbcontext();

        // GET: api/CNInfoes
        public IQueryable<CNInfo> GetCNInfoset()
        {
            IQueryable<CNInfo> CNList = db.CNInfoset.OrderByDescending(cn=>cn.CNInfoId).Take(5);
            foreach (var cn in CNList)
            {
                PartyInfo Party = db.PartyInfoset.Where(p => p.PartyInfoId.ToString() == cn.PartyId).FirstOrDefault();
                cn.Ex1 = Party.Name;
            }
            return CNList;
        }
        public IQueryable<CNInfo> LoadAllCNInfoset()
        {

            return db.CNInfoset;
        }

        // GET: api/CNInfoes/5
        [ResponseType(typeof(CNInfo))]
        public IHttpActionResult GetCNInfo(int id)
        {
            CNInfo cNInfo = db.CNInfoset.Find(id);
            if (cNInfo == null)
            {
                return NotFound();
            }

            return Ok(cNInfo);
        }

        // PUT: api/CNInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCNInfo(int id, CNInfo cNInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cNInfo.CNInfoId)
            {
                return BadRequest();
            }

            db.Entry(cNInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNInfoExists(id))
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

        // POST: api/CNInfoes
        [ResponseType(typeof(CNInfo))]
        public IHttpActionResult PostCNInfo(CNInfo cNInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CNInfoset.Add(cNInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cNInfo.CNInfoId }, cNInfo);
        }

        // DELETE: api/CNInfoes/5
        [ResponseType(typeof(CNInfo))]
        public IHttpActionResult DeleteCNInfo(int id)
        {
            CNInfo cNInfo = db.CNInfoset.Find(id);
            if (cNInfo == null)
            {
                return NotFound();
            }

            db.CNInfoset.Remove(cNInfo);
            db.SaveChanges();

            return Ok(cNInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CNInfoExists(int id)
        {
            return db.CNInfoset.Count(e => e.CNInfoId == id) > 0;
        }
    }
}