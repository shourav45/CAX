using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.ApiControllers
{
    public class BulkUploadController : Controller
    {
        // GET: BulkUpload
        [System.Web.Http.HttpPost]
        public ActionResult UploadExcel()
        {
            var rq = Request.Files[0];
            string PartyId = Request.Form["PartyName"];
            var CNDate = Request.Form["CNDate"];

            return Json("0", JsonRequestBehavior.AllowGet);
        }
    }
}