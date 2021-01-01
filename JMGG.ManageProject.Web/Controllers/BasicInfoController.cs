using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model.BasicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{

    public class BasicInfoController : Controller
    {
        private static readonly BasicInfoLogic basicInfoLogic = new BasicInfoLogic();

        // GET: BasicInfo
        public ActionResult Index()
        {
            ViewBag.IsAdmin = true;
            return View("~/Views/BasicInfo/Index.cshtml");
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

                var paramRequest = new BasicInfoRequest
                {
                    PageIndex = page,
                    PageSize = limit
                };
                if (paramRequest.PageIndex == 0)
                    paramRequest.PageIndex = 1;
                else
                    paramRequest.PageIndex = (paramRequest.PageIndex / 10) + 1;

                var result = basicInfoLogic.QueryUserListPage(paramRequest);
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
                return Json(new BasicInfoPageResponse()  { code = 9 });
            }
        }

    }
}