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
    public class PlanReportController : BaseController
    {
        private static readonly PlanReportLogic planLogic = new PlanReportLogic();

        // GET: PlanReport
        public ActionResult Index()
        {
            var NewAdPlanId = string.IsNullOrEmpty(Request["NewAdPlanId"]) ? "" : Request["NewAdPlanId"];
            var IsAdmin = string.IsNullOrEmpty(Request["IsAdmin"]) ? "" : Request["IsAdmin"];
            ViewBag.NewAdPlanId = NewAdPlanId;
            ViewBag.IsAdmin = IsAdmin == "1";

            ViewBag.UserLoginName = base.UserInfo.CompanyName + "[ID:" + base.UserInfo.BusinessID + "]";
            return View("~/Views/PlanReport/Report.cshtml");
        }

        /// <summary>
        /// 报表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAdPlanReportList()
        {
            try
            {
                int page = !string.IsNullOrEmpty(Request["page"]) ? Convert.ToInt32(Request["page"]) : 1;
                int limit = !string.IsNullOrEmpty(Request["limit"]) ? Convert.ToInt32(Request["limit"]) : 10;

                var ADName = Request["ADName"] ?? "";
                var NewAdPlanId = Request["NewAdPlanId"] ?? "";
                var IsAdmin = Request["IsAmdin"] ?? "";
                var startLaunchTime = Request["StartLaunchTime"] ?? "";
                var endLaunchTime = Request["EndLaunchTime"] ?? "";
                var Status = Request["Status"] ?? "";
                var ADPlanID = Request["ADPlanID"] ?? "";
                var NewAdPlanID = Request["NewAdPlanID"] ?? "";

                if (startLaunchTime == "" || endLaunchTime == "")
                {
                    return Json(new PlanReportPageResponse() { code = -1, msg = "请选择开始和结束时间" });
                }
                //if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(startLaunchTime).AddDays(-30)) > 0)
                //{

                //}
                TimeSpan ts1 = new TimeSpan(Convert.ToDateTime(startLaunchTime).Ticks);
                TimeSpan ts2 = new TimeSpan(Convert.ToDateTime(endLaunchTime).Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                if (ts.Days > 30)
                {
                    return Json(new PlanReportPageResponse() { code = -1, msg = "时间范围不能超出30天" });
                }
                var paramRequest = new PlanReportRequest
                {
                    PageIndex = page,
                    PageSize = limit,
                    UserManageId = base.UserInfo.UserManageID,
                    AdName = ADName,
                    NewAdPlanId = NewAdPlanId,
                    StartTime = endLaunchTime,
                    EndTime = startLaunchTime,
                    LaunchStatus = Status,
                    IsAmdin = IsAdmin == "1"
                };
                if (paramRequest.PageIndex == 0)
                    paramRequest.PageIndex = 1;
                else
                    paramRequest.PageIndex = (paramRequest.PageIndex / 10) + 1;

                var result = planLogic.QueryPlanRepostListPage(paramRequest);
                if (result != null && result.count > 0)
                {
                    result.msg = "SUCCESS";
                    result.code = 0;
                }
                else
                {
                    result.msg = "未查询到数据";
                    result.code = -1;
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                LogWriter.error($"GetAdPlanReportList=>获取广告信息异常：{ex.ToString() + ex.Message}");
                return Json(new PlanReportPageResponse() { code = -1, msg = "未查询到数据" });
            }
        }
    }
}