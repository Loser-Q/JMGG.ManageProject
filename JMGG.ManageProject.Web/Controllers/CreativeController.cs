using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model.Creative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{

    public class CreativeController : BaseController
    {
        private static readonly CreativeLogic CreativeLogic = new CreativeLogic();

        // GET: CreativePlan
        public ActionResult Index()
        {
            ViewBag.IsAdmin = false;
            ViewBag.UserLoginName = base.UserInfo.CompanyName + "[ID:" + base.UserInfo.BusinessID + "]";
            return View("~/Views/Creative/Index.cshtml");
        }
        public ActionResult From()
        {
            ViewBag.IsAdmin = false;
            ViewBag.UserLoginName = base.UserInfo.CompanyName + "[ID:" + base.UserInfo.BusinessID + "]";
            return View("~/Views/Creative/From.cshtml");
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

                var Introduce = Request["Introduce"] ?? "";
                var SourceID = Request["SourceID"] ?? "";

                var paramRequest = new CreativeRequest
                {
                    PageIndex = page,
                    PageSize = limit,
                    Introduce = Introduce,
                    SourceID = SourceID,
                };
                if (paramRequest.PageIndex == 0)
                    paramRequest.PageIndex = 1;
                else
                    paramRequest.PageIndex = (paramRequest.PageIndex / 10) + 1;

                var result = CreativeLogic.QueryUserListPage(paramRequest);
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
                return Json(new CreativePageResponse()  { code = 9 });
            }
        }

    }
}