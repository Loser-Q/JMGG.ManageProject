using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model;
using JMGG.ManageProject.Model.CreativePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{

    public class CreativePlanController : BaseController
    {
        private static readonly CreativePlanLogic CreativePlanLogic = new CreativePlanLogic();
        private static readonly AdPlanLogLogic adPlanLog = new AdPlanLogLogic();

        // GET: CreativePlan
        public ActionResult Index()
        {
            ViewBag.IsAdmin = false;
            ViewBag.UserLoginName = base.UserInfo.CompanyName + "[ID:" + base.UserInfo.BusinessID + "]";
            return View("~/Views/CreativePlan/Index.cshtml");
        }
        public ActionResult From()
        {
            ViewBag.IsAdmin = false;
            ViewBag.UserLoginName = base.UserInfo.CompanyName + "[ID:" + base.UserInfo.BusinessID + "]";
            return View("~/Views/CreativePlan/From.cshtml");
        }
        /// <summary>
        /// 广告计划
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
                    ADName = ADName,
                    BusinessPlanID = BusinessPlanID,
                    endLaunchTime = endLaunchTime,
                    startLaunchTime = startLaunchTime,
                    Status = Status,
                    IsAdmin = false,
                    UserManageId = base.UserInfo.UserManageID
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
                return Json(new CreativePlanPageResponse() { code = 9 });
            }
        }

        /// <summary>
        /// 更新广告状态
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateAdvertPlanStatus()
        {
            var isError = false;
            StringBuilder strLog = new StringBuilder();
            strLog.Append($"UpdateAdvertPlanStatus=>更新广告状态\r\n");
            try
            {
                //调用接口方法使用
                var planId = Request["planId"] ?? "";
                var draft_id = Request["draft_id"] ?? "";
                //本地使用
                var newPlanId = Request["newPlanId"] ?? "";
                var id = Request["id"] ?? "0";
                var operationType = Request["operationType"] ?? "";  //操作类型 1：开 2：关
                strLog.Append($"参数:原计划ID：{planId},draft_id:{draft_id},newPlanId:{newPlanId},id:{id},operationType:{operationType}\r\n");
                if (string.IsNullOrWhiteSpace(planId) || string.IsNullOrWhiteSpace(draft_id))
                {
                    return Json(new { result = false, msg = "暂时无法更新广告状态，请联系管理员操作！" });
                }
                //调用接口方法


                //更新本地数据库状态
                var resUpdate = CreativePlanLogic.UpdateAdPlanBySwitch(new CreativePlanEntity
                {
                    Id = Convert.ToInt32(id),
                    Switch = operationType == "1" ? "1" : "2",
                    Status = operationType == "1" ? "2" : "7"
                });
                strLog.Append($"更新广告状态:{resUpdate}\r\n");

                //查询广告信息
                var planEntity = CreativePlanLogic.QueryCreativePlanById(Convert.ToInt32(id));
                var updateLog = operationType == "1" ? "开启广告计划" : "关闭广告计划";
                //插入日志
                var logRes = adPlanLog.InsertAdPlanLog(new AdPlanyLogEntity
                {
                    UserMangeId = base.UserInfo.UserManageID,
                    UserName = base.UserInfo.UserName,
                    BusinessId = base.UserInfo.BusinessID,
                    BusinessPlanID = planEntity.BusinessPlanID,
                    ADPlanID = planEntity.NewAdPlanID,
                    ADName = planEntity.ADName,
                    BillingMethod = planEntity.BillingMethod,
                    OperationType = "修改",
                    CreateUser = base.UserInfo.UserName,
                    OldJson = $"状态:{(operationType == "1" ? "关" : "开")}",
                    NewJson = $"状态:{(operationType == "1" ? "开" : "关")}"
                });
                strLog.Append($"更新广告状态日志:{logRes}\r\n");

                return Json(new { msg = "", result = false });
            }
            catch (Exception ex)
            {
                isError = true;
                strLog.Append($"异常:{ex.ToString() + ex.StackTrace}");
                return Json(new { msg = "异常，请联系管理员处理", result = false });
            }
            finally
            {
                if (isError)
                    LogWriter.error(strLog.ToString());
                else
                    LogWriter.info(strLog.ToString());
            }
        }
    }
}