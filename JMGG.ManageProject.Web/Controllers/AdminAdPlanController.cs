using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model;
using JMGG.ManageProject.Model.CreativePlan;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{
    public class AdminAdPlanController : BaseController
    {
        private static readonly CreativePlanLogic creativePlanLogic = new CreativePlanLogic();
        private static readonly AdPlanLogLogic adPlanLog = new AdPlanLogLogic();
        // GET: AdminAdPlan
        public ActionResult Index()
        {
            ViewBag.IsAdmin = true;
            return View("~/Views/AdminAdPlan/AdminAdPlan.cshtml");
        }

        /// <summary>
        /// 广告计划
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAdPlanList()
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
                var ADPlanID = Request["ADPlanID"] ?? "";
                var NewAdPlanID = Request["NewAdPlanID"] ?? "";

                var paramRequest = new CreativePlanRequest
                {
                    PageIndex = page,
                    PageSize = limit,
                    ADName = ADName,
                    BusinessPlanID = BusinessPlanID,
                    endLaunchTime = endLaunchTime,
                    startLaunchTime = startLaunchTime,
                    Status = Status,
                    IsAdmin = true,
                    NewAdPlanID = NewAdPlanID,
                    AdPlanID = ADPlanID
                };
                if (paramRequest.PageIndex == 0)
                    paramRequest.PageIndex = 1;
                else
                    paramRequest.PageIndex = (paramRequest.PageIndex / 10) + 1;

                var result = creativePlanLogic.QueryUserListPage(paramRequest);
                if (result != null && result.count > 0)
                {
                    result.msg = "SUCCESS";
                    result.code = 0;
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                LogWriter.error($"GetAdPlanList=>获取广告信息异常：{ex.ToString() + ex.Message}");
                return Json(new CreativePlanPageResponse() { code = -1, msg = "未查询到数据" });
            }
        }

        /// <summary>
        /// 更新广告计划
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateAdPlan()
        {
            var param = string.IsNullOrEmpty(Request["param"]) ? "" : Request["param"];
            if (param == "")
                return Json(new BaseResponse { result = false, msg = "参数不能为空" });
            var userObj = JsonConvert.DeserializeObject<CreativePlanEntity>(param);
            var oldPlanEntity = creativePlanLogic.QueryCreativePlanById(userObj.Id);
            var res = creativePlanLogic.UpdateAdPlanById(userObj);
            if (res && oldPlanEntity != null)
            {
                //保存日志
                var oldStr = "";
                var newStr = "";
                if (userObj.Switch != oldPlanEntity.Switch)
                {
                    oldStr += "开关:" + oldPlanEntity.Switch + "\r\n";
                    newStr += "开关:" + userObj.Switch + "\r\n";
                }
                if (userObj.NewDayBudget != oldPlanEntity.NewDayBudget)
                {
                    oldStr += "单日预算:" + oldPlanEntity.NewDayBudget + "\r\n";
                    newStr += "单日预算:" + userObj.NewDayBudget + "\r\n";
                }
                if (userObj.NewUnitPrice != oldPlanEntity.NewUnitPrice)
                {
                    oldStr += "单价:" + oldPlanEntity.NewUnitPrice + "\r\n";
                    newStr += "单价:" + userObj.NewUnitPrice + "\r\n";
                }
                if (userObj.ADPlanID != oldPlanEntity.ADPlanID)
                {
                    oldStr += "原系统计划ID:" + oldPlanEntity.ADPlanID + "\r\n";
                    newStr += "原系统计划ID:" + userObj.ADPlanID + "\r\n";
                }
                if (userObj.Status != oldPlanEntity.Status)
                {
                    oldStr += "状态:" + GetStatus(oldPlanEntity.Status) + "\r\n";
                    newStr += "状态:" + GetStatus(userObj.Status) + "\r\n";
                }
                var logRes = adPlanLog.InsertAdPlanLog(new AdPlanyLogEntity
                {
                    UserMangeId = base.UserInfo.UserManageID,
                    UserName = base.UserInfo.UserName,
                    BusinessId = base.UserInfo.BusinessID,
                    BusinessPlanID = oldPlanEntity.BusinessPlanID,
                    ADPlanID = oldPlanEntity.NewAdPlanID,
                    ADName = oldPlanEntity.ADName,
                    BillingMethod = oldPlanEntity.BillingMethod,
                    OperationType = "修改",
                    CreateUser = base.UserInfo.UserName,
                    OldJson = oldStr,
                    NewJson = newStr
                });
            }
            return Json(new BaseResponse { result = res, msg = res ? "成功" : "失败" });
        }

        public string GetStatus(string status)
        {
            var statusStr = "";
            switch (status)
            {
                case "1":
                    statusStr = "待投放";
                    break;
                case "2":
                    statusStr = "投放中";
                    break;
                case "3":
                    statusStr = "已结束";
                    break;
                case "4":
                    statusStr = "等待审核中";
                    break;
                case "5":
                    statusStr = "未通过审核";
                    break;
                case "6":
                    statusStr = "待提交审核";
                    break;
                case "7":
                    statusStr = "已暂停";
                    break;
            }
            return statusStr;
        }
    }
}