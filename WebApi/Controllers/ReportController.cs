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

        public ActionResult CNUserEntryReport(DateTime CNDate,int CNDestination)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();
           
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
        public ActionResult CNFullManifest(DateTime CNDate, int CNDestination)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult CNPartManifest(DateTime CNDate, int CNDestination)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult SaleDailyTotal(DateTime SaleDate, string SaleSOPName)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult SaleSPOReport(DateTime SaleDate, string SaleSOPName)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult SaleSPOTotalReport(DateTime SaleDate, string SaleSOPName)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult BillMonthly(DateTime BillDate, int PartyId,string CNType,int Discount)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult BillMonthlyDetails(DateTime BillDate, int PartyId, string CNType, int Discount)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult PartyFolioReport(DateTime PartyDate, int PartyId, string UpdateStatus)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult PartyShipperCopy(DateTime PartyDate, int PartyId, string UpdateStatus)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult PartyNonUpdateReport(DateTime PartyDate, int PartyId, string UpdateStatus)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult PartyUpdateReport(DateTime PartyDate, int PartyId, string UpdateStatus)
        {
            db = new dbcontext();
            List<CNInfo> cnData = db.CNInfoset.ToList();

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
        public ActionResult QuickPrint(int CN)
        {
            db = new dbcontext();
          List<CNInfo> cnData = db.CNInfoset.Where(c=>c.CNInfoId==CN).ToList();
            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;

            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptSingleCN.rdlc");

            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", cnData));
            viewer.LocalReport.Refresh();

            var bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return File(bytes, mimeType);
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