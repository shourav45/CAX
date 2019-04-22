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
        public dbcontext db=new dbcontext();
        private string connection = ConfigurationManager.ConnectionStrings["ConnString1"].ConnectionString;

        public ActionResult CNReport(DateTime FromDate,int UserId)
        {
            HttpCookie myCookie = Request.Cookies["UserCookie"];
            int myname =Convert.ToInt32(myCookie.Values["UserInfoId"]);
            string PrintUser = myCookie.Values["Name"].ToString();
            List<SqlParameter> pram = new List<SqlParameter>();
            SqlParameter p1 = new SqlParameter("@FromDate", FromDate);
            SqlParameter p2 = new SqlParameter("@User", UserId);
            pram.Add(p1);
            pram.Add(p2);
            DataTable dt = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "CNListPrint", pram.ToArray()).Tables[0];

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
            ReportParameter rptparam = new ReportParameter();
            rptparam = new ReportParameter("PrintUser", PrintUser);

            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptPrintCNList.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            viewer.LocalReport.SetParameters(rptparam);
            viewer.LocalReport.Refresh();

            var bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return File(bytes, mimeType);
        }
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
            var viewer = new ReportViewer();
            List<ReportParameter> param = new List<ReportParameter>();

            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptUserEntry.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

            param.Add(new ReportParameter("CNDate", CNDate.ToShortDateString()));
            if(CNDestination=="0")
            {
                param.Add(new ReportParameter("Dest","All"));
            }
            else
            {
                param.Add(new ReportParameter("Dest", dt.Rows[0][4].ToString()));
            }
            viewer.LocalReport.SetParameters(param);
            viewer.LocalReport.Refresh();

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
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

           // List<VMCNCargoManifest> dt = SqlHelper.ExecuteDataTable("", "CargoManifest", new object[] { CNDate, CNDestination }).ToList<VMCNCargoManifest>();
            var viewer = new ReportViewer();
            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("CNDate", CNDate.ToShortDateString()));
            var des = db.Destinationset.Where(d => d.DestinationId == CNDestination).FirstOrDefault();
            param.Add(new ReportParameter("Dest", des.Area+" ("+des.District+")"));
            // var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptFullManifest.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            viewer.LocalReport.SetParameters(param);
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
        public ActionResult BillMonthly(DateTime BillDate, int PartyId,string CNType,string Discount,string Vat)
        {
            double d = Convert.ToDouble(Discount);
            double v= Convert.ToDouble(Vat);
            db = new dbcontext();
            List<SqlParameter> pram = new List<SqlParameter>();
            SqlParameter p1 = new SqlParameter("@CNDate", BillDate);
            SqlParameter p2 = new SqlParameter("@PartyId", PartyId);
            SqlParameter p3 = new SqlParameter("@CNType", CNType);
            pram.Add(p1);
            pram.Add(p2);
            pram.Add(p3);
            DataTable dt = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "MonthlyBillPartyWise", pram.ToArray()).Tables[0];
            double TotalBill = 0,DiscountAmount=0,VatAmount=0;
            foreach(DataRow item in dt.Rows)
            {
                TotalBill = TotalBill+Convert.ToInt32(item["TotalAmount"]);
            }
            if(d!=0)
            {
               double a1=TotalBill / 100;
                DiscountAmount =(d* a1);
            }
            if(v!=0)
            {
                double a2 = TotalBill / 100;
                VatAmount = (v * a2);
            }
            double AfterVat = TotalBill + VatAmount;
            double AfterDiscount = AfterVat - DiscountAmount;

            var party = db.PartyInfoset.Where(p => p.PartyInfoId == PartyId).FirstOrDefault();
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("CNMonth", BillDate.ToShortDateString()));
            param.Add(new ReportParameter("PartyName", party.Name));
            param.Add(new ReportParameter("PartyAddress", party.Address));
            param.Add(new ReportParameter("DiscountAmount", DiscountAmount.ToString()));
            param.Add(new ReportParameter("DiscountPercent",Discount.ToString()));
            param.Add(new ReportParameter("VatPercent", Vat.ToString()));
            param.Add(new ReportParameter("VatAmount", VatAmount.ToString()));
            param.Add(new ReportParameter("TotalAmount", TotalBill.ToString()));
            param.Add(new ReportParameter("AfterVat", AfterVat.ToString()));
            param.Add(new ReportParameter("AfterDiscount", AfterDiscount.ToString()));

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;

            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptMonthlyBillParty.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            viewer.LocalReport.SetParameters(param);
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
            
            List<SqlParameter> pram = new List<SqlParameter>();
            SqlParameter p1 = new SqlParameter("@CNDate", PartyDate);
            SqlParameter p2 = new SqlParameter("@PartyId", PartyId);
            pram.Add(p1);
            pram.Add(p2);
            DataTable dt = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "ShipperCopy", pram.ToArray()).Tables[0];

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
            var party = db.PartyInfoset.Where(p => p.PartyInfoId == PartyId).FirstOrDefault();
            List<ReportParameter> rptparam = new List<ReportParameter>();
            rptparam.Add(new ReportParameter("CNMonth", PartyDate.ToShortDateString()));
            rptparam.Add(new ReportParameter("PartyName", party.Name));

            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptShipperCopy.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            viewer.LocalReport.SetParameters(rptparam);
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
            HttpCookie myCookie = Request.Cookies["UserCookie"];
            string myname = myCookie.Values["Name"].ToString();
            List<ReportParameter> param = new List<ReportParameter>();
            param.Add(new ReportParameter("PrintUser", myname));
         
            List<SqlParameter> pram = new List<SqlParameter>();
            SqlParameter p1 = new SqlParameter("@CNId", CN);
            pram.Add(p1);
            DataTable dt = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "CNQuickPrint", pram.ToArray()).Tables[0];

            Warning[] warnings;
            string mimeType;
            string[] streamids;
            string encoding;
            string filenameExtension;
            ReportParameter rptparam = new ReportParameter();
            var viewer = new ReportViewer();
            viewer.LocalReport.ReportPath = Server.MapPath("~/RDLC/rptSingleCN.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            rptparam = new ReportParameter("PrintUser", myname);
            viewer.LocalReport.SetParameters(rptparam);
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