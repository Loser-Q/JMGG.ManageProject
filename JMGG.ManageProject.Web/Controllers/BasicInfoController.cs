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
            var userInfo = userLogic.QueryUserInfoByBusinessID(new UserInfo
            {
                UserManageId = base.UserInfo.UserManageID,
            });
            if (userInfo != null && !string.IsNullOrEmpty(userInfo.BizInfoJson))
            {
                var bizInfoObj = JsonConvert.DeserializeObject<BizInfoEntity>(userInfo.BizInfoJson);
                userInfo.BizInfo = bizInfoObj;
            }
            return View("~/Views/BasicInfo/From.cshtml", userInfo);
        }
    }
}