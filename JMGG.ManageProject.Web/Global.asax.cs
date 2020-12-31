using JMGG.ManageProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JMGG.ManageProject.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The _app version
        /// </summary>
        public static readonly string AppVersion = DateTime.Now.ToString("yyyyMMddHHmm");
        protected void Application_Start()
        {
            InitDbConnectionStringConfig();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpContext.Current.Application["APPVersion"] = AppVersion;
        }

        /// <summary>
        /// 初始化数据库连接
        /// </summary>
        private static void InitDbConnectionStringConfig()
        {
            var dbConnectionStringConfig = new DBConnectionStringConfig();
            //数据库连接字符串      
            var JMGGConStr = ConfigurationManager.ConnectionStrings["JMGGConnectionString"];

            dbConnectionStringConfig.JMGGConnectionString = JMGGConStr.ConnectionString;
            DBConnectionStringConfig.InitDefault(dbConnectionStringConfig);
        }
    }
}
