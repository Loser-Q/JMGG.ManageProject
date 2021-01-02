using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model.CreativePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{

    public class CreativePlanController : BaseController
    {
        private static readonly CreativePlanLogic CreativePlanLogic = new CreativePlanLogic();

        // GET: CreativePlan
        public ActionResult Index()
        {
            ViewBag.IsAdmin = false;
            ViewBag.UserLoginName = base.UserInfo.CompanyName + "[ID:" + base.UserInfo.BusinessID + "]";
            return View("~/Views/CreativePlan/Index.cshtml");
        }
        /// <summary>
        /// 基础信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList()
        {
            try
            {
                int page = !string.IsNullOrEmpty(Request["page"]) ? Convert.ToInt32(Request["page"]) : 1;
                int limit = !string.IsNullOrEmpty(Request["limit"]) ? Convert.ToInt32(Request["limit"]) : 10;

                var ADName = Request["ADName"] ?? "";
                var BusinessPlanID = Request["BusinessPlanID"] ?? "";
                var startLaunchTime = Request["startLaunchTime"] ?? "";
                var endLaunchTime = Request["endLaunchTime"] ?? "";
                var Status = Request["Status"] ?? "";

                var paramRequest = new CreativePlanRequest
                {
                    PageIndex = page,
                    PageSize = limit,
                    ADName =ADName,
                    BusinessPlanID = BusinessPlanID,
                    endLaunchTime = endLaunchTime,
                    startLaunchTime = startLaunchTime,
                    Status = Status
                };
                if (paramRequest.PageIndex == 0)
                    paramRequest.PageIndex = 1;
                else
                    paramRequest.PageIndex = (paramRequest.PageIndex / 10) + 1;

                var result = CreativePlanLogic.QueryUserListPage(paramRequest);
                if (result != null && result.count > 0)
                {
                    result.msg = "SUCCESS";
                    result.code = 0;
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                LogWriter.error($"GetUserManageList=>获取基础信息的异常：{ex.ToString() + ex.Message}");
                return Json(new CreativePlanPageResponse()  { code = 9 });
            }
        }

    }
}