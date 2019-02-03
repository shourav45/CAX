using System;
using System.Collections.Generic;
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
            return View();
        }
        public ActionResult Poly()
        {
            return View();
        }
        public ActionResult OtherBooking()
        {
            return View();
        }
        public ActionResult DeliveryStatus()
        {
            return View();
        }
        public ActionResult CNPrint()
        {
            return View();
        }
        public ActionResult Accounts()
        {
            return View();
        }

        public ActionResult BillInfoReport()
        {
            return View();
        }
        public ActionResult CNInfoReport()
        {
            return View();
        }
        public ActionResult SalesReport()
        {
            return View();
        }
        public ActionResult PartyReport()
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
