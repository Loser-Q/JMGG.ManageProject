using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers
{
    public class BaseController : Controller
    {

        //加密解密key
        private string encryptKey = ConfigurationManager.AppSettings["EncryptKey"];
        private string COOKIEKEY = "LoginYSYD";
        private string SESSIONKEY = "Login";

        /// <summary>
        /// 登录信息
        /// </summary>
        public UserInfo UserInfo
        {
            get
            {
                var loginUser = Session[SESSIONKEY];
                if (loginUser != null)
                {
                    //解密
                    var decryParma = ManagePass.Decrypt(loginUser.ToString(), encryptKey);
                    var UserInfo = JsonConvert.DeserializeObject<UserInfo>(decryParma);
                    return UserInfo;
                }
                else
                {
                    return new UserInfo();
                }
            }
        }

        /// <summary>
        /// 身份验证，Action执行前判断
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isError = false;
            StringBuilder logBuiler = new StringBuilder();
            var loginUser = filterContext.HttpContext.Session[SESSIONKEY];
            try
            {
                #region 1.Session不为空，写入Cookie
                if (loginUser != null)
                {
                    if (Request.Cookies[COOKIEKEY] == null)
                    {
                        //-------Cookie写入----------
                        HttpCookie cookie = new HttpCookie(COOKIEKEY);//定义cookie对象以及名为Info的项 
                        DateTime dt = DateTime.Now;//定义时间对象 
                        TimeSpan ts = new TimeSpan(0, 12, 30, 0);//cookie有效作用时间，具体查msdn (0, 12, 0, 0)
                        cookie.Expires = dt.Add(ts);//添加作用时间 
                        cookie.Values.Add("userfineral", loginUser.ToString());//增加属性 
                        Response.AppendCookie(cookie);//确定写入cookie中                           
                                                      //--------------------------
                    }
                    else
                    {
                        string cookUserStr = Convert.ToString(Request.Cookies[COOKIEKEY].Values["userfineral"]);
                        if (!string.IsNullOrWhiteSpace(cookUserStr) && loginUser.ToString() != cookUserStr)
                        {
                            //-------Cookie写入----------
                            HttpCookie cookie = new HttpCookie(COOKIEKEY);//定义cookie对象以及名为Info的项 
                            DateTime dt = DateTime.Now;//定义时间对象 
                            TimeSpan ts = new TimeSpan(0, 12, 30, 0);//cookie有效作用时间，具体查msdn (0, 12, 0, 0)
                            cookie.Expires = dt.Add(ts);//添加作用时间 
                            cookie.Values.Add("userfineral", loginUser.ToString());//增加属性 
                            Response.AppendCookie(cookie);//确定写入cookie中                           
                                                          //--------------------------
                        }
                    }
                }
                #endregion

                #region 2.Session为空，Cookie不为空时，通过Cookie来给Session重新赋值
                if (loginUser == null && Request.Cookies[COOKIEKEY] != null)
                {
                    string loginUserStr = Convert.ToString(Request.Cookies[COOKIEKEY].Values["userfineral"]);
                    if (!string.IsNullOrWhiteSpace(loginUserStr))
                    {
                        try
                        {
                            UserInfo loginUserCookie = JsonConvert.DeserializeObject<UserInfo>(ManagePass.Decrypt(loginUserStr, encryptKey));
                            logBuiler.Append(string.Format("{0}\r\n{1}\r\n{2}\\r\n", loginUserCookie.Mobile, "使用过cookie恢复session登录", "用户session"));
                            filterContext.HttpContext.Session[SESSIONKEY] = loginUserStr;
                            filterContext.HttpContext.Session.Timeout = 180;
                        }
                        catch (Exception ex)
                        {
                            isError = true;
                            logBuiler.Append(string.Format("{0}\r\n{1}\r\n{2}", "cookie读取 失败", ex.ToString(), "Exception"));
                        }
                    }
                }
                #endregion

                #region 3.Session为空时重新登录平台
                if (filterContext.HttpContext.Session[SESSIONKEY] == null)
                {
                    logBuiler.Append($"SESSION为空，重新登录后台，地址:/Login/Index\r\n");
                    //alert('由于您长时间未操作页面,请重新登录');
                    filterContext.HttpContext.Response.Write($"<script type='text/javascript'>top.location='/Login/Index'</script>");
                    filterContext.HttpContext.Response.End();
                }
                #endregion
            }
            catch (Exception ex)
            {
                isError = true;
                logBuiler.Append($"OnActionExecuting=>【{DateTime.Now}】获取登录信息异常：{ex.ToString() + ex.Message}\r\n");
            }
            finally
            {
                if (!string.IsNullOrWhiteSpace(logBuiler.ToString()))
                {
                    if (isError)
                        LogWriter.error(logBuiler.ToString(), LogWriter.GetFramesString());
                    else
                        LogWriter.info(logBuiler.ToString(), LogWriter.GetFramesString());
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }

}