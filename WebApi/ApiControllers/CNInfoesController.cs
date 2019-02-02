using Newtonsoft.Json;
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

namespace WebApi.ApiControllers
{
    public class CNInfoesController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: api/CNInfoes
        [System.Web.Http.HttpGet]
        public ActionResult GetCNInfoset()
        {
            List<CNInfo> CNList = db.CNInfoset.OrderByDescending(cn=>cn.CNInfoId).Take(5).ToList();
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
        public ActionResult PostCNInfo(string CNType, string PolySize, string CNDate, string ServiceType, string PartyId, string Destination,
            string Follio, string ConsingeeName, string ConsigneeAddress, string ItemInfo, string Kgpiece, string RateType, string Weight,
            string ServiceCharge, string VatStatus, string VatPercent, string VatAmount, string AitStatus, string AitPercent,
            string AitAmount, string TotalAmount, string Size, string KPNumber, string Ex1)
        {
            CNInfo cn = new CNInfo();
            cn.CNType = CNType;
            cn.PolySize = PolySize;
            cn.CNDate = DateTime.Now; 
                //Convert.ToDateTime(CNDate);
            cn.ServiceType = ServiceType;
            cn.PartyId = PartyId;
            cn.Destination = Destination;
            cn.Follio = Follio;
            cn.ConsingeeName = ConsingeeName;
            cn.ConsigneeAddress = ConsigneeAddress;
            cn.ItemInfo = ItemInfo;
            cn.Kgpiece = Kgpiece;
            cn.RateType = RateType;
            cn.Weight = Weight;
            cn.ServiceCharge = ServiceCharge;
            cn.VatStatus = VatStatus;
            cn.VatPercent = VatPercent;
            cn.VatAmount = VatAmount;
            cn.AitStatus = AitStatus;
            cn.AitPercent = AitPercent;
            cn.AitAmount = AitAmount;
            cn.TotalAmount = TotalAmount;
            cn.Size = Size;
            cn.KPNumber = KPNumber;
            cn.Ex1=Ex1;
            if (!ModelState.IsValid)
            {
                return Json("Model is not valid", JsonRequestBehavior.AllowGet);
            }

            db.CNInfoset.Add(cn);
            db.SaveChanges();

            return Json(cn, JsonRequestBehavior.AllowGet);
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