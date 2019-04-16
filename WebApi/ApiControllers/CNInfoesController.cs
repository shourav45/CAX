using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebApi.Models;

namespace WebApi.ApiControllers
{
    public class CNInfoesController : Controller
    {
        private dbcontext db = new dbcontext();
        // GET: api/CNInfoes
        [System.Web.Http.HttpGet]
        public ActionResult GetCNInfoset()
        {
            HttpCookie myCookie = Request.Cookies["UserCookie"];
            string myname = myCookie.Values["UserInfoId"].ToString();
            List<CNInfo> CNList = db.CNInfoset.OrderByDescending(cn=>cn.CNInfoId).Where(cn=>cn.AddBy== myname).Take(100).ToList();
            foreach (var cn in CNList)
            {
                PartyInfo Party = db.PartyInfoset.Where(p => p.PartyInfoId.ToString() == cn.PartyId).FirstOrDefault();
                if(Party!=null)
                {
                    cn.Ex1 = Party.Name;
                }
            }
            return Json(CNList,JsonRequestBehavior.AllowGet);
        }
        [System.Web.Http.HttpGet]
        public ActionResult LastCNNumber()
        {
            HttpCookie myCookie = Request.Cookies["UserCookie"];
            string myname = myCookie.Values["UserInfoId"].ToString();
            var CNList = db.CNInfoset.Where(c=>c.AddBy==myname).ToList().LastOrDefault();

            return Json(CNList, JsonRequestBehavior.AllowGet);
        }
        public IQueryable<CNInfo> LoadAllCNInfoset()
        {

            return db.CNInfoset;
        }

        // GET: api/CNInfoes/5
        [System.Web.Http.HttpGet]
        public ActionResult GetCNInfoById(int id)
        {
            CNInfo cNInfo = db.CNInfoset.Find(id);
            if (cNInfo == null)
            {
                return Json("0",JsonRequestBehavior.AllowGet);
            }

            return Json(cNInfo,JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult UpdateCNInfo(int id, CNInfo cNInfo)
        {
            if (!ModelState.IsValid)
            {
                return Json("Model is not valid",JsonRequestBehavior.AllowGet);
            }

            if (id != cNInfo.CNInfoId)
            {
                return Json("Model is not valid", JsonRequestBehavior.AllowGet);
            }

            HttpCookie myCookie = Request.Cookies["UserCookie"];
            cNInfo.AddBy = myCookie.Values["UserInfoId"].ToString();

            db.Entry(cNInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNInfoExists(id))
                {
                    return Json("Model not found", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw;
                }
            }

            return Json(cNInfo,JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult PostCNInfo(CNInfo cn)
        {
            if (ModelState.IsValid==false)
            {
                var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
                string msg = "";
                foreach (var item in errors)
                {
                    foreach (var ermsg in item)
                    {
                        msg = msg + ermsg.ErrorMessage;
                    }
                }
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            HttpCookie myCookie = Request.Cookies["UserCookie"];
            cn.AddBy = myCookie.Values["UserInfoId"].ToString();
            cn.AddDate = DateTime.Now.ToString();
            cn.Status = "A";
            cn.Ex1 = "";
            cn.DeliveryStatus = "0";
            //cn.ServiceCharge = "0";//need to add on the form
            db.CNInfoset.Add(cn);
           var result= db.SaveChanges();
            return Json(cn.CNInfoId, JsonRequestBehavior.AllowGet);
        }

        // DELETE: api/CNInfoes/5
        [System.Web.Http.HttpGet]
        public ActionResult DeleteCNInfo(int id)
        {
            CNInfo cNInfo = db.CNInfoset.Find(id);
            if (cNInfo == null)
            {
                return Json("Model not found", JsonRequestBehavior.AllowGet);
            }

            db.CNInfoset.Remove(cNInfo);
            db.SaveChanges();

            return Json(cNInfo, JsonRequestBehavior.AllowGet);
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