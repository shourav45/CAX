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
                worksheet.Cells[1, 1].Value = "CN Type";
                worksheet.Cells[1, 2].Value = "Destination";
                worksheet.Cells[1, 3].Value = "Fo/L No";
                worksheet.Cells[1, 4].Value = "Consingee Name";
                worksheet.Cells[1, 5].Value = "Consignee Address";
                worksheet.Cells[1, 6].Value = "Item Info";
                worksheet.Cells[1, 7].Value = "Size";
                worksheet.Cells[1, 8].Value = "Total Piece/Weight";
                worksheet.Cells[1, 9].Value = "Service Charge";
                worksheet.Cells[1, 10].Value = "Total Amount";
                worksheet.Cells[1, 11].Value = "Others";
                //sample data
                worksheet.Cells[2, 1].Value = "Document";
                worksheet.Cells[2, 2].Value = "Barisal";
                worksheet.Cells[2, 3].Value = "111";
                worksheet.Cells[2, 4].Value = "Rafiq Hossain";
                worksheet.Cells[2, 5].Value = "MOhammadpur, Dhaka";
                worksheet.Cells[2, 6].Value = "Cheque book";
                worksheet.Cells[2, 7].Value = "Big";
                worksheet.Cells[2, 8].Value = "300";
                worksheet.Cells[2, 9].Value = "10";
                worksheet.Cells[2, 10].Value = "3010";
                worksheet.Cells[2, 11].Value = "Others";
                
                //var cell = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[row, 1];
                //cell.Validation.Delete();
                //cell.Validation.Add(
                //   XlDVType.xlValidateList,
                //   XlDVAlertStyle.xlValidAlertInformation,
                //   XlFormatConditionOperator.xlBetween,
                //   flatList,
                //   Type.Missing);

                //cell.Validation.IgnoreBlank = true;
                //cell.Validation.InCellDropdown = true;

                worksheet.DefaultColWidth = 18;
                worksheet.DefaultRowHeight = 20;
                
                var rngTable = worksheet.Cells["A1:K1"];
                rngTable.Style.Fill.PatternType = ExcelFillStyle.Solid;
                rngTable.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(253, 233, 217));
                rngTable.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                rngTable.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                

                memStream = new MemoryStream(package.GetAsByteArray());
            }
            return File(memStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CN Bulk Upload Sample format.xlsx");
        }
        public ActionResult Reports()
        {
            int Auth = AuthCheck();
            if (Auth == 1)
                return View();
            return RedirectToAction("Login", "Home");
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
