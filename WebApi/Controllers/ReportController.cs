using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using WebApi.Models.ViewModels;

namespace WebApi.Controllers
{
    public class ReportController : Controller
    {
        private dbcontext db;
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DayReport()
        {
            return View();
        }

        public ActionResult GetDailyReport()
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();
            //var rptData = from c in db.CNInfoset
            //              join p in db.PartyInfoset on c.PartyId equals p.PartyInfoId
            //              select new VMDailyInfo
            //              {
            //                  Amount = Convert.ToDecimal(c.TotalAmount),
            //                  PartyName = p.Name
            //              };


            //for rdlc
            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;

            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptDailySales.rdlc");

            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", cnData));
            viewer.LocalReport.Refresh();

            var bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return File(bytes, mimeType);
        }
    }
}