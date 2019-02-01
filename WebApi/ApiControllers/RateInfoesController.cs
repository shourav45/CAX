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
using System.Web.Mvc;
using WebApi.Models;
using System.Web.Http;
namespace WebApi.ApiControllers
{
    public class RateInfoesController : Controller
    {
        private dbcontext db = new dbcontext();

        [System.Web.Mvc.HttpGet]
        public ActionResult GetRateAllRate()
        {
            List<RateInfo> RateList = db.RateInfoset.ToList();
            foreach (var rate in RateList)
            {
                PartyInfo Party = db.PartyInfoset.Where(p => p.PartyInfoId.ToString() == rate.PartyInfoId).FirstOrDefault();
                rate.Ex1 = Party.Name;
            }
            return Json(RateList,JsonRequestBehavior.AllowGet);
        }

      [System.Web.Http.HttpGet]
        public ActionResult GetRateById(int id)
        {
            RateInfo rateInfo = db.RateInfoset.Find(id);
            if (rateInfo == null)
            {
                return Json("Not Found",JsonRequestBehavior.AllowGet);
            }

            return Json(rateInfo, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public ActionResult GetRateByPartyId(string PartyId, string RateType)
        {
            var rateInfo = db.RateInfoset.Where(r=>r.PartyInfoId== PartyId && r.RateType.Equals(RateType, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (rateInfo.Count <= 0)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }

            return Json(rateInfo, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult PutRateInfo(int id, RateInfo rateInfo)
        {
            if (!ModelState.IsValid)
            {
                return Json("Model is not valid", JsonRequestBehavior.AllowGet);
            }

            if (id != rateInfo.RateInfoId)
            {
                return Json("Model id is not valid", JsonRequestBehavior.AllowGet);
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
                    return Json("Data is not in table", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw;
                }
            }

            return Json(rateInfo, JsonRequestBehavior.AllowGet);
        }

        // POST: api/RateInfoes
        [System.Web.Http.HttpPost]
        public ActionResult PostRateInfo(string PartyInfoId,string RateType,string FirstKP,string  FirstKPRate,string AfterFirstKPRate,string Ex1)
        {
            RateInfo rateInfo = new Models.RateInfo();
            rateInfo.PartyInfoId = PartyInfoId;
            rateInfo.RateType = RateType;
            rateInfo.FirstKP = FirstKP;
            rateInfo.FirstKPRate = FirstKPRate;
            rateInfo.AfterFirstKPRate = AfterFirstKPRate;
            rateInfo.Ex1 = Ex1;

            if (!ModelState.IsValid)
            {
                return Json("Model is not valid", JsonRequestBehavior.AllowGet);
            }

            db.RateInfoset.Add(rateInfo);
            db.SaveChanges();

            return Json(rateInfo,JsonRequestBehavior.AllowGet);
        }

        // DELETE: api/RateInfoes/5
     [System.Web.Http.HttpPost]
        public ActionResult DeleteRateInfo(int id)
        {
            RateInfo rateInfo = db.RateInfoset.Find(id);
            if (rateInfo == null)
            {
                return Json("Model not found", JsonRequestBehavior.AllowGet);
            }

            db.RateInfoset.Remove(rateInfo);
            db.SaveChanges();

            return Json(rateInfo, JsonRequestBehavior.AllowGet); ;
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