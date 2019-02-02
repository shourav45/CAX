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
    public class UserInfoesController : ApiController
    {
        private dbcontext db = new dbcontext();

        // GET: api/UserInfoes
        public IQueryable<UserInfo> GetUserInfoset()
        {
            IQueryable <UserInfo> List= db.UserInfoset;
            foreach(var item in List)
            {
                item.UserPassword = "*";
            }
            return List;
        }

        // GET: api/UserInfoes/5
        [ResponseType(typeof(UserInfo))]
        public IHttpActionResult GetUserInfo(int id)
        {
            UserInfo userInfo = db.UserInfoset.Find(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        // PUT: api/UserInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserInfo(int id, UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfo.UserInfoId)
            {
                return BadRequest();
            }

            db.Entry(userInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
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

        // POST: api/UserInfoes
        [ResponseType(typeof(UserInfo))]
        public IHttpActionResult PostUserInfo(UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserInfoset.Add(userInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userInfo.UserInfoId }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [ResponseType(typeof(UserInfo))]
        public IHttpActionResult DeleteUserInfo(int id)
        {
            UserInfo userInfo = db.UserInfoset.Find(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            db.UserInfoset.Remove(userInfo);
            db.SaveChanges();

            return Ok(userInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInfoExists(int id)
        {
            return db.UserInfoset.Count(e => e.UserInfoId == id) > 0;
        }
    }
}