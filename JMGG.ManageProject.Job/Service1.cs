using JMGG.ManageProject.Common;
using JMGG.ManageProject.DataAccess;
using JMGG.ManageProject.Job.Job;
using JMGG.ManageProject.Model.Job;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Job
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();

            //定时刷新数据库
            int time = Convert.ToInt32(ConfigurationManager.AppSettings["Timed"]);
            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = time;
            t.Elapsed += new System.Timers.ElapsedEventHandler(TimedExecuteJob);
            t.AutoReset = true;
            t.Enabled = true;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                LogWriter.info("服务启动" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                List<SchedulerConfigModel> list = SchedulerConfigQuery.GetSchedulerRecord((int)JobEnum.DataType.EnableData);
                if (list != null && list.Count > 0)
                {
                    for (var i = 0; i < list.Count; i++)
                    {
                        ExecuteWebApi(list[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.error("服务启动异常：" + ex.ToString());
            }
        }

        protected override void OnStop()
        {
            try
            {
                SchedulerHelper op = new SchedulerHelper();
                op.shutdown();
                LogWriter.info("服务结束" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                LogWriter.error("服务结束异常：" + ex.ToString());
            }
        }

        /// <summary>
        /// 定时执行事件
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void TimedExecuteJob(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                SchedulerHelper scheduler = new SchedulerHelper();
                //查询变动的数据
                List<SchedulerConfigModel> list = SchedulerConfigQuery.GetSchedulerRecord((int)JobEnum.DataType.UpdateData);
                if (list == null || list.Count == 0)
                {
                    return;
                }
                for (var i = 0; i < list.Count; i++)
                {
                    //新增|更新
                    if (list[i].Status == (int)JobEnum.DataState.Insert || list[i].Status == (int)JobEnum.DataState.Update)
                    {
                        var _delete = scheduler.IsExistsDelJob(list[i].JobName, list[i].JobGroup);
                        if (_delete)
                        {
                            //启用新的Job
                            var _update = ExecuteWebApi(list[i]);
                            if (_update)
                                SchedulerConfigQuery.UpdateStatus(list[i].ID);
                        }
                    }
                    //禁用Job
                    else if (list[i].Status == (int)JobEnum.DataState.Delete)
                    {
                        var _delete = scheduler.IsExistsDelJob(list[i].JobName, list[i].JobGroup);
                        LogWriter.info("Job-" + list[i].JobName + (_delete ? "已禁用" : "禁用失败") + ",执行时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        if (_delete)
                            SchedulerConfigQuery.UpdateStatus(list[i].ID);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.error("定时获取数据库数据执行Job异常：" + ex.ToString() + "/r/n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 执行Job方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool ExecuteWebApi(SchedulerConfigModel list)
        {
            try
            {
                var flag = true;
                SchedulerHelper scheduler = new SchedulerHelper();

                SchedulerRequest request = new SchedulerRequest();
                request.JobName = list.JobName;
                request.JobGroup = list.JobGroup;
                request.TriggerName = list.JobName + "Trigger";
                request.TriggerGroupName = list.JobGroup + "Trigger";
                request.CronTab = list.CronTab;
                request.StartTime = list.StartTime;
                if (list.EndTime != null)
                    request.EndTime = list.EndTime;
                else
                    request.EndTime = null;
                request.RequestType = list.RequestType;
                request.RequestUrl = list.RequestUrl;

                var json = JsonConvert.SerializeObject(request);

                DateTimeOffset? end = null;
                if (request.EndTime != null)
                {
                    end = DateTime.SpecifyKind(Convert.ToDateTime(request.EndTime), DateTimeKind.Local);
                    if (request.EndTime < DateTime.Now)
                        flag = false;
                }
                if (flag)
                {
                    IJobDetail jobDetail = JobBuilder.Create<JobMethod>()
                     .WithIdentity(request.JobName, request.JobGroup)
                     .UsingJobData("jobJson", json)
                     .Build();

                    CronTriggerImpl tigger = (CronTriggerImpl)TriggerBuilder.Create()
                     .WithIdentity(request.TriggerName, request.TriggerGroupName)
                     .WithCronSchedule(request.CronTab)
                     .ForJob(request.JobName, request.JobGroup)
                     .StartNow()
                     .EndAt(end)
                     .Build();

                    DateTimeOffset dt = scheduler.scheduleJob(jobDetail, tigger);

                    LogWriter.info("[" + (request.RequestType == (int)JobEnum.RequestType.Get ? "GET" : "POST") + "]Job-" + request.JobName + "已启动,定时运行时间为:" + Convert.ToDateTime(dt.ToString()) + ",请求地址:" + request.RequestUrl);
                }
                else
                {
                    LogWriter.info("[" + (request.RequestType == (int)JobEnum.RequestType.Get ? "GET" : "POST") + "]Job-" + request.JobName + ",当前时间超出此Job设置的执行结束时间,该Job已停止执行,请求地址:" + request.RequestUrl);
                }

                return true;
            }
            catch (Exception ex)
            {
                LogWriter.error("Job-" + list.JobName + "执行异常,请求地址:" + list.RequestUrl + ",异常信息:" + ex.ToString());
                //插入日志
                SchedulerRequest request = new SchedulerRequest();
                request.JobGroup = list.JobGroup;
                request.JobName = list.JobName;
                request.RequestType = list.RequestType;
                request.RequestUrl = list.RequestUrl;
                request.ReturnMsg = "Job-Exception: " + (ex.ToString().Length > 490 ? ex.ToString().Substring(0, 490) : ex.ToString());
                request.LogStatus = (int)JobEnum.LogStatus.ExceptInfo;
                SchedulerConfigQuery.InsertLog(request);
                //数据状态更新为0,防止重复执行
                SchedulerConfigQuery.UpdateStatus(list.ID);
                return false;
            }
        }
    }
}
