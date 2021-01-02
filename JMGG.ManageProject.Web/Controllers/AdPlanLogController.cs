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
    public class AdPlanLogController : BaseController
    {
        private static readonly AdPlanLogLogic adPlanLogLogic = new AdPlanLogLogic();

        // GET: AdPlanLog
        public ActionResult Index()
        {
            var businessPlanId = !string.IsNullOrEmpty(Request["businessPlanId"]) ? Request["businessPlanId"] : "";
            var adPlanId = !string.IsNullOrEmpty(Request["adPlanId"]) ? Request["adPlanId"] : "";
            ViewBag.BusinessPlanId = businessPlanId;
            ViewBag.AdPlanId = adPlanId;
            return View();
        }

        /// <summary>
        /// 操作日志列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetADPlanList()
        {
            try
            {
                int page = !string.IsNullOrEmpty(Request["page"]) ? Convert.ToInt32(Request["page"]) : 1;
                int limit = !string.IsNullOrEmpty(Request["limit"]) ? Convert.ToInt32(Request["limit"]) : 10;
                var businessPlanId = !string.IsNullOrEmpty(Request["businessPlanId"]) ? Request["businessPlanId"] : "";
                var adPlanId = !string.IsNullOrEmpty(Request["adPlanId"]) ? Request["adPlanId"] : "";
                if (businessPlanId == "" || adPlanId == "")
                {
                    return Json(new AdPlanyLogPageResponse { code = -1, msg = "无数据" });
                }
                var paramRequest = new AdPlanyLogRequest
                {
                    UserManageId = base.UserInfo.UserManageID,
                    AdPlanId = adPlanId,
                    BussinessPlanId = businessPlanId,
                    PageIndex = page,
                    PageSize = limit
                };
                if (paramRequest.PageIndex == 0)
                    paramRequest.PageIndex = 1;
                else
                    paramRequest.PageIndex = (paramRequest.PageIndex / 10) + 1;

                var result = adPlanLogLogic.QueryAdPlanLogListPage(paramRequest);
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
                LogWriter.error($"GetADPlanList=>获取操作日志信息异常：{ex.ToString() + ex.Message}");
                return Json(new AdPlanyLogPageResponse() { code = 9 });
            }
        }
    }
}