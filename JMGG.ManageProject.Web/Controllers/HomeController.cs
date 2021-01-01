using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (base.UserInfo != null)
            {
                ViewBag.CompanyName = base.UserInfo.CompanyName;
                ViewBag.BussinID = base.UserInfo.BusinessID;
            }

            return View();
        }
    }
}