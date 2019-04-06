using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        private string connection = ConfigurationManager.ConnectionStrings["ConnString1"].ConnectionString;
        public ActionResult CNUserEntryReport(DateTime CNDate,string CNDestination)
        {
            db = new dbcontext();
            //List<CNInfo> cnData = db.CNInfoset.ToList();
            if (CNDestination == "undefined")
            {
                CNDestination = "0";
            }

            List<SqlParameter> pram = new List<SqlParameter>();
            SqlParameter p1 = new SqlParameter("@CNDate",CNDate);
            SqlParameter p2 = new SqlParameter("@DestinationId", CNDestination);
            pram.Add(p1);
            pram.Add(p2);
            DataTable dt= SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "UserCNEntryCount",pram.ToArray()).Tables[0];

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptUserEntry.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            viewer.LocalReport.Refresh();
            var bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            return File(bytes, mimeType);
        }
        public ActionResult CNFullManifest(DateTime CNDate, int CNDestination)
        {
            List<SqlParameter> pram = new List<SqlParameter>();
            SqlParameter p1 = new SqlParameter("@CNDate", CNDate);
            SqlParameter p2 = new SqlParameter("@DestinationId", CNDestination);
            pram.Add(p1);
            pram.Add(p2);
            DataTable dt = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "CargoManifest", pram.ToArray()).Tables[0];

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
            List<ReportParameter> param = new List<ReportParameter>();
            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptFullManifest.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            viewer.LocalReport.Refresh();

            var bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return File(bytes, mimeType);
        }
        public ActionResult CNPartManifest(DateTime CNDate, int CNDestination)
        {
            List<SqlParameter> pram = new List<SqlParameter>();
            SqlParameter p1 = new SqlParameter("@CNDate", CNDate);
            SqlParameter p2 = new SqlParameter("@DestinationId", CNDestination);
            pram.Add(p1);
            pram.Add(p2);
            DataTable dt = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "CargoManifest", pram.ToArray()).Tables[0];

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
            List<ReportParameter> param = new List<ReportParameter>();
            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptFullManifest.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
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
            List<SqlParameter> pram = new List<SqlParameter>();
            SqlParameter p1 = new SqlParameter("@CNId", CN);
            pram.Add(p1);
            DataTable dt = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "CNQuickPrint", pram.ToArray()).Tables[0];

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
            List<ReportParameter> param = new List<ReportParameter>();
            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptSingleCN.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
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