using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public int AuthCheck()
        {
            HttpCookie myCookie = Request.Cookies["UserCookie"];
            if (myCookie == null)
            {
                return 0;
            }
            else
            {
                try
                {
                    string Name = myCookie.Values["Name"].ToString();
                    string Mobile1 = myCookie.Values["Mobile1"].ToString();
                    string Pass = myCookie.Values["UserPassword"].ToString();
                    UserInfo user = db.UserInfoset.Where(u => u.Mobile1 == Mobile1 && u.Name == Name && u.UserPassword==Pass).FirstOrDefault();
                    if (user == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        private dbcontext db = new dbcontext();
        public ActionResult Login()
        {
            HttpCookie myCookie = Request.Cookies["UserCookie"];
            if (myCookie == null || myCookie.Expires < DateTime.Now)
            {
                return View();
            }
            else
            {
                try
                {
                    string Name = myCookie.Values["Name"].ToString();
                    string Mobile1 = myCookie.Values["Mobile1"].ToString();
                    string Pass = myCookie.Values["UserPassword"].ToString();
                    UserInfo user = db.UserInfoset.Where(u => u.Mobile1 == Mobile1 && u.Name == Name && u.UserPassword == Pass).FirstOrDefault();
                    if (user == null)
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
        }
        [HttpGet]
        public ActionResult LoginCheck(string UName,string Mobile,string Pass)
        {
            UserInfo user = db.UserInfoset.Where(u => u.Mobile1 == Mobile && u.Name == UName).FirstOrDefault();
            if(user==null || user.UserPassword!=Pass)
            {
                return Json("Incorrect Password",JsonRequestBehavior.AllowGet);
            }
            //create a cookie
            HttpCookie myCookie = new HttpCookie("UserCookie");
            //Add key-values in the cookie
            myCookie.Values.Add("Name", user.Name.ToString());
            myCookie.Values.Add("Mobile1", user.Mobile1.ToString());
            myCookie.Values.Add("UserPassword", user.UserPassword.ToString());
            myCookie.Values.Add("Designation", user.Designation.ToString());
            myCookie.Values.Add("UserAccess", user.UserRole.ToString());
            //set cookie expiry date-time. Made it to last for next 12 hours.
            myCookie.Expires = DateTime.Now.AddHours(12);
            //Most important, write the cookie to client.
            Response.Cookies.Add(myCookie);

            return Json(user,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
           int Auth= AuthCheck();
            if(Auth==1)
            return View();
            return RedirectToAction("Login","Home");
        }

        public ActionResult AddUser()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult AddSPO()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Zonal()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Rate()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult AddParty()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Document()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Parcel()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Poly()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult OtherBooking()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult CNList()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult BulkUpload()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult DownloadExcel()
        {
            MemoryStream memStream;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("CN Bulk Upload");
                worksheet.Cells[1, 1].Value = "CNType";
                worksheet.Cells[1, 2].Value = "DeliveryStatus";
                worksheet.Cells[1, 3].Value = "Status";
                worksheet.Cells[1, 4].Value = "CNDate";
                worksheet.Cells[1, 5].Value = "PartyId";
                worksheet.Cells[1, 6].Value = "Destination";
                worksheet.Cells[1, 7].Value = "Follio";
                worksheet.Cells[1, 8].Value = "ConsingeeName";
                worksheet.Cells[1, 9].Value = "ConsigneeAddress";
                worksheet.Cells[1, 10].Value = "ItemInfo";
                worksheet.Cells[1, 11].Value = "Kgpiece";
                worksheet.Cells[1, 12].Value = "Weight";
                worksheet.Cells[1, 13].Value = "ServiceCharge";
                worksheet.Cells[1, 14].Value = "TotalAmount";
                worksheet.Cells[1, 15].Value = "Size";
                worksheet.Cells[1, 16].Value = "KPNumber";
                var rngTable = worksheet.Cells["A1:E1"];
                rngTable.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rngTable.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(253, 233, 217));
                rngTable.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

                memStream = new MemoryStream(package.GetAsByteArray());
            }
            return File(memStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CN Bulk Upload Sample format.xlsx");
        }
        public ActionResult DeliveryStatus()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult CNPrint()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Accounts()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }

        
        public ActionResult BillInfoReport()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult CNInfoReport()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult SalesReport()
        {
            return View();
        }
        public ActionResult PartyReport()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            HttpCookie myCookie = new HttpCookie("UserCookie");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            return RedirectToAction("Login","Home");
        }
    }
}
