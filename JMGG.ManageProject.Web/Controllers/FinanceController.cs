using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{
    public class FinanceController : BaseController
    {
        private static readonly FinanceInfoLogic financeLogic = new FinanceInfoLogic();
        private static readonly AccountBalanceLogic balanceLogic = new AccountBalanceLogic();

        // GET: Finance
        public ActionResult Index()
        {
            ViewBag.IsAdmin = false;
            ViewBag.UserLoginName = base.UserInfo.CompanyName + "[ID:" + base.UserInfo.BusinessID + "]";
            //获取总余额
            var balanceAmount = balanceLogic.QueryBalanceByUserId(new AccountBalanceEntity { UserName = base.UserInfo.UserName, BusinessId = base.UserInfo.BusinessID });
            ViewBag.TotalBalanceAmount = "0.00";
            if (balanceAmount != null && !string.IsNullOrWhiteSpace(balanceAmount.NewFinanceTotalBanalceAmount))
            {
                ViewBag.TotalBalanceAmount = balanceAmount.NewFinanceTotalBanalceAmount;
            }
            return View();
        }

        /// <summary>
        /// 财务列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetFinanceList()
        {
            try
            {
                int page = !string.IsNullOrEmpty(Request["page"]) ? Convert.ToInt32(Request["page"]) : 1;
                int limit = !string.IsNullOrEmpty(Request["limit"]) ? Convert.ToInt32(Request["limit"]) : 10;
                var startTime = !string.IsNullOrEmpty(Request["startTime"]) ? Request["startTime"] : "";
                var endTime = !string.IsNullOrEmpty(Request["endTime"]) ? Request["endTime"] : "";

                var paramRequest = new FinanceInfoRequest
                {
                    UserName = base.UserInfo != null ? base.UserInfo.UserName : "-",
                    BussinessID = base.UserInfo != null ? base.UserInfo.BusinessID : "-",
                    StartTime = startTime,
                    EndTime = endTime,
                    PageIndex = page,
                    PageSize = limit
                };
                if (paramRequest.PageIndex == 0)
                    paramRequest.PageIndex = 1;
                else
                    paramRequest.PageIndex = (paramRequest.PageIndex / 10) + 1;

                var result = financeLogic.QueryFinanceListPage(paramRequest);
                if (result != null && result.count > 0)
                {
                    result.msg = "SUCCESS";
                    result.code = 0;
                }
                else
                {
                    result.msg = "无数据";
                    result.code = -1;
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                LogWriter.error($"GetUserManageList=>获取财务信息的异常：{ex.ToString() + ex.Message}");
                return Json(new FinanceInfoPageResponse() { code = 9 });
            }
        }
    }
}