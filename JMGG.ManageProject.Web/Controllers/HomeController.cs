using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model;
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

        private AccountBalanceLogic balanceLogic = new AccountBalanceLogic();

        public ActionResult Index()
        {
            var isAdmin = false;
            var balanceEntity = new AccountBalanceEntity();
            balanceEntity.NewAccountConsumeBalance = "0.00";
            balanceEntity.NewAccountTotalBalance = "0.00";
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
                balanceEntity = balanceLogic.QueryBalanceByUserId(new Model.AccountBalanceEntity { BusinessId = base.UserInfo.BusinessID, UserName = base.UserInfo.UserName });
            }
            if (balanceEntity == null)
            {
                balanceEntity = new AccountBalanceEntity();
                balanceEntity.NewAccountConsumeBalance = "0.00";
                balanceEntity.NewAccountTotalBalance = "0.00";
            }
            ViewBag.IsAdmin = isAdmin;

            return View(balanceEntity);
        }
    }
}