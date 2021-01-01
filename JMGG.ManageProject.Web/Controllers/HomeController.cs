using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{
    public class HomeController : BaseController
    {
        private string AdminAccount = ConfigurationManager.AppSettings["AdminAccount"];

        public ActionResult Index()
        {
            var isAdmin = false;
            if (base.UserInfo != null)
            {
                ViewBag.CompanyName = base.UserInfo.CompanyName;
                ViewBag.BussinID = base.UserInfo.BusinessID;

                //判断是不是管理员账号
                if (base.UserInfo.UserName == AdminAccount.Split('|')[0])
                {
                    isAdmin = true;
                    return Redirect("/UserManage/Index");
                }
            }
            ViewBag.IsAdmin = isAdmin;
            return View();
        }
    }
}