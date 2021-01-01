using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model;
using JMGG.ManageProject.Model.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{
    public class UserManageController : BaseController
    {
        private static readonly UserManageLogic userMangeLogic = new UserManageLogic();

        // GET: UserManage
        public ActionResult Index()
        {
            ViewBag.IsAdmin = true;
            return View("~/Views/UserManage/UserManage.cshtml");
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserManageList()
        {
            try
            {
                int page = !string.IsNullOrEmpty(Request["page"]) ? Convert.ToInt32(Request["page"]) : 1;
                int limit = !string.IsNullOrEmpty(Request["limit"]) ? Convert.ToInt32(Request["limit"]) : 10;
                var businessID = !string.IsNullOrEmpty(Request["UserId"]) ? Request["UserId"] : "";
                var userName = !string.IsNullOrEmpty(Request["UserName"]) ? Request["UserName"] : "";

                var paramRequest = new UseManageRequest
                {
                    UserName = userName,
                    BussinessID = businessID,
                    PageIndex = page,
                    PageSize = limit
                };
                if (paramRequest.PageIndex == 0)
                    paramRequest.PageIndex = 1;
                else
                    paramRequest.PageIndex = (paramRequest.PageIndex / 10) + 1;

                var result = userMangeLogic.QueryUserListPage(paramRequest);
                if (result != null && result.count > 0)
                {
                    result.msg = "SUCCESS";
                    result.code = 0;
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                LogWriter.error($"GetUserManageList=>获取用户信息的异常：{ex.ToString() + ex.Message}");
                return Json(new UseManagePageResponse() { code = 9 });
            }
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddUser()
        {
            var param = string.IsNullOrEmpty(Request["param"]) ? "" : Request["param"];
            if (param == "")
                return Json(new BaseResponse { result = false, msg = "请求参数不能为空" });

            var userObj = JsonConvert.DeserializeObject<UseManageEntity>(param);
            userObj.BussinessID = userObj.UserId;
            userObj.CreateTime = DateTime.Now;
            userObj.IsDelete = 0;
            userObj.CreateUser = base.UserInfo != null ? base.UserInfo.UserName : "";
            var userInfo = userMangeLogic.InsertUser(userObj);
            return Json(userInfo);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BathDeleteUser()
        {
            var param = string.IsNullOrEmpty(Request["ids"]) ? "" : Request["ids"];
            if (param == "")
                return Json(new BaseResponse { result = false, msg = "请求参数不能为空" });

            var userInfo = userMangeLogic.DeleteUser(param.Split(',').Select(p => Convert.ToInt32(p)).ToList());
            return Json(new BaseResponse { result = userInfo, msg = userInfo ? "删除成功" : "删除失败" });
        }
    }
}