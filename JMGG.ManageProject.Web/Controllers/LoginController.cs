using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{
    public class LoginController : Controller
    {
        //private static UserLogic userLogic = new UserLogic();
        private static UserManageLogic userManageLogic = new UserManageLogic();
        //加密解密key
        private static string encryptKey = ConfigurationManager.AppSettings["EncryptKey"];

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <returns></returns>
        public JsonResult LoginSystem()
        {
            string loginUsername = string.IsNullOrEmpty(Request["loginUsername"]) ? "" : Request["loginUsername"];
            string loginPassword = string.IsNullOrEmpty(Request["loginPassword"]) ? "" : Request["loginPassword"];
            if (loginUsername == "" || loginPassword == "")
            {
                return Json(new { result = false, msg = "未获取到登录信息，请联系管理员处理!" });
            }
            var userInfo = userManageLogic.QueryUserByPassword(new UseManageRequest
            {
                UserName = loginUsername,
                PassWord = loginPassword
            });
            if (userInfo != null)
            {
                //将用户信息赋值到session
                Session["Login"] = ManagePass.Encrypt(JsonConvert.SerializeObject(new LoginInfo { UserName = loginUsername, BusinessID = userInfo.BussinessID, CompanyName = userInfo.CompanyName }), encryptKey);
                return Json(new { result = true, msg = "登录成功" });
            }
            else
            {
                return Json(new { result = false, msg = "账号密码不正确，请重新输入" });
            }
        }

        public ActionResult LoginOut()
        {
            Session["Login"] = null;
            HttpCookie Cookie = Request.Cookies["LoginYSYD"];
            Cookie.Expires = DateTime.Now.AddDays(-1);//设置过期时间
            Response.Cookies.Add(Cookie);//响应一个Cookies

            return Redirect("/Login/Index");
        }
    }
}