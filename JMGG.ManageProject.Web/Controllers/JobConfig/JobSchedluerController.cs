using JMGG.ManageProject.Business;
using JMGG.ManageProject.Common;
using JMGG.ManageProject.Model.Job;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JMGG.ManageProject.Web.Controllers.JobConfig
{
    public class JobSchedluerController : BaseController
    {
        private SchedulerConfigLogic bll = new SchedulerConfigLogic();

        // GET: JobSchedluer
        public ActionResult Index()
        {
            ViewBag.isAmdin = true;
            return View();
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        public string ValiationPwd()
        {
            var flag = false;
            var password = string.IsNullOrEmpty(Request["password"]) ? string.Empty : Request["password"].ToString();
            var pwd = ConfigurationManager.AppSettings["JobConfigPwd"].ToString().Trim();

            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(pwd))
            {
                if (password == pwd)
                {
                    flag = true;
                }
            }
            return JsonConvert.SerializeObject(new { status = flag ? "true" : "false" });
        }

        /// <summary>
        /// 查询Job记录
        /// </summary>
        /// <param name="context"></param>
        public string QuerySchedluer()
        {
            try
            {
                var PageIndex = Convert.ToInt32(Request["page"]) == 0 ? 1 : Convert.ToInt32(Request["page"]);
                var PageSize = Convert.ToInt32(Request["rows"]) == 0 ? 20 : Convert.ToInt32(Request["rows"]);
                var QueryParams = string.IsNullOrEmpty(Request["params"]) ? string.Empty : Request["params"].ToString();
                string SchedulerJson = string.Empty;
                if (!string.IsNullOrEmpty(QueryParams))
                {
                    var QueryModel = JsonConvert.DeserializeObject<SchedulerConfigModel>(QueryParams);
                    int total = bll.GetTotalJobCount(QueryModel);
                    QueryModel.PageIndex = PageIndex;  //页码
                    QueryModel.PageSize = PageSize;  //每页条数
                    var ProviderList = bll.QueryListByConditionPage(QueryModel);

                    SchedulerJson = JsonConvert.SerializeObject(new { rows = ProviderList, total = total });
                }
                return SchedulerJson;
            }
            catch (Exception ex)
            {
                LogWriter.error($"查询Job记录异常：{ex.Message + ex.StackTrace}");
                return JsonConvert.SerializeObject(new { rows = "", total = 0 });
            }
        }

        /// <summary>
        /// 新增数据|修改数据
        /// </summary>
        /// <param name="context"></param>
        public string AddOrUpdateSchedulerConfig()
        {
            try
            {
                var QueryParams = string.IsNullOrEmpty(Request["params"]) ? string.Empty : Request["params"].ToString();

                if (!string.IsNullOrEmpty(QueryParams))
                {
                    var QueryModel = JsonConvert.DeserializeObject<SchedulerConfigModel>(QueryParams);

                    //新增
                    if (QueryModel.ID == 0)
                    {
                        var flag = bll.JobNameCount(QueryModel.JobName);
                        if (flag)
                        {
                            return JsonConvert.SerializeObject(new { returnMsg = "JobName不能重复,请重新命名！", status = "false", code = 1 });
                        }

                        QueryModel.IsEnable = 1; //默认Job启用
                        QueryModel.Status = 1;
                        QueryModel.CreateUser = "admin";
                        QueryModel.LastUpdateUser = "admin";
                        var num = bll.AddSchedulerConfig(QueryModel);
                        if (num > 0)
                            return JsonConvert.SerializeObject(new { returnMsg = "新增成功", status = "true" });
                        else
                            return JsonConvert.SerializeObject(new { returnMsg = "新增失败", status = "false" });
                    }
                    //修改
                    else
                    {
                        QueryModel.LastUpdateTime = DateTime.Now;
                        //启用状态下修改状态才更新成2
                        QueryModel.Status = QueryModel.IsEnable == 1 ? 2 : 0;
                        QueryModel.CreateUser = "admin";
                        QueryModel.LastUpdateUser = "admin";
                        var flag = bll.UpdateSchedulerConfig(QueryModel);
                        if (flag)
                            return JsonConvert.SerializeObject(new { returnMsg = "更新成功", status = "true" });
                        else
                            return JsonConvert.SerializeObject(new { returnMsg = "更新失败", status = "false" });
                    }
                }
                else
                {
                    return JsonConvert.SerializeObject(new { returnMsg = "操作失败", status = "false" });
                }
            }
            catch (Exception ex)
            {
                LogWriter.error($"新增数据|修改数据异常{ex.Message + ex.StackTrace}");
                return JsonConvert.SerializeObject(new { status = "false" });
            }
        }

        /// <summary>
        /// 批量更新job启动状态
        /// </summary>
        /// <param name="context"></param>
        public string UpdateSchedulerConfigStatus()
        {
            try
            {
                var Ids = string.IsNullOrEmpty(Request["Ids"]) ? string.Empty : Request["Ids"].ToString();
                var IsEnable = string.IsNullOrEmpty(Request["IsEnable"]) ? -1 : Convert.ToInt32(Request["IsEnable"]);
                var Name = string.IsNullOrEmpty(Request["Name"]) ? string.Empty : Request["Name"].ToString();

                if (!string.IsNullOrEmpty(Ids) && IsEnable >= 0)
                {
                    SchedulerConfigModel SchedulerConfigModel = new SchedulerConfigModel();
                    SchedulerConfigModel.LastUpdateTime = DateTime.Now;
                    SchedulerConfigModel.LastUpdateUser = Name;
                    SchedulerConfigModel.IsEnable = IsEnable;
                    SchedulerConfigModel.Status = IsEnable == 0 ? 3 : 1;

                    var flag = bll.UpdateSchedulerConfigStatus(Ids, SchedulerConfigModel);
                    if (flag)
                        return JsonConvert.SerializeObject(new { returnMsg = "更新成功", status = "true" });
                    else
                        return JsonConvert.SerializeObject(new { returnMsg = "更新失败", status = "false" });
                }
                else
                {
                    return JsonConvert.SerializeObject(new { returnMsg = "更新失败", status = "false" });
                }
            }
            catch (Exception ex)
            {
                LogWriter.error($"批量更新job启动状态异常{ex.Message + ex.StackTrace}");
                return JsonConvert.SerializeObject(new { returnMsg = "更新异常", status = "false" });
            }
        }

        /// <summary>
        /// 查询Job日志记录
        /// </summary>
        /// <param name="context"></param>
        public string QueryLogSchedluer()
        {
            try
            {
                var PageIndex = Convert.ToInt32(Request["page"]) == 0 ? 1 : Convert.ToInt32(Request["page"]);
                var PageSize = Convert.ToInt32(Request["rows"]) == 0 ? 20 : Convert.ToInt32(Request["rows"]);
                var QueryParams = string.IsNullOrEmpty(Request["params"]) ? string.Empty : Request["params"].ToString();
                string SchedulerJson = string.Empty;
                if (!string.IsNullOrEmpty(QueryParams))
                {
                    var QueryModel = JsonConvert.DeserializeObject<SchedulerLogModel>(QueryParams);
                    int total = bll.GetJobLogCount(QueryModel);
                    QueryModel.PageIndex = PageIndex;  //页码
                    QueryModel.PageSize = PageSize;  //每页条数
                    var ProviderList = bll.QueryListByLogPage(QueryModel);

                    SchedulerJson = JsonConvert.SerializeObject(new { rows = ProviderList, total = total });
                }
                return SchedulerJson;
            }
            catch (Exception ex)
            {
                LogWriter.error($"查询Job日志记录异常{ ex.Message + ex.StackTrace}");
                return JsonConvert.SerializeObject(new { rows = "", total = 0 });
            }
        }
    }
}