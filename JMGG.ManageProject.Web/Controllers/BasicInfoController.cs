using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model.Creative;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JMGG.ManageProject.Model.User;
using Newtonsoft.Json;

namespace JMGG.ManageProject.Web.Controllers
{

    public class BasicInfoController : BaseController
    {
        private static readonly UserLogic userLogic = new UserLogic();

        // GET: CreativePlan
        public ActionResult From()
        {
            ViewBag.IsAdmin = false;
            ViewBag.UserLoginName = base.UserInfo.CompanyName + "[ID:" + base.UserInfo.BusinessID + "]";
            return View("~/Views/BasicInfo/From.cshtml");
        }

        /// <summary>
        /// 基础信息
        /// </summary>
        /// <returns></returns>
        public JsonResult QueryInfo()
        {

            var BussinessID = Request["BussinessID"] ?? "";

           

            var userInfo = userLogic.QueryUserInfoByBusinessID(new UserInfo
            {
                BussinessID = base.UserInfo.BusinessID,
            });
            if (userInfo != null)
            {

                return Json(new { result = true, msg = "获取成功！" ,data= userInfo });
            }
            else
            {
                return Json(new { result = false, msg = "获取失败！" });
            }
        }
    }
}