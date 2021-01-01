using JMGG.ManageProject.Common;
using JMGG.ManageProject.DataAccess;
using JMGG.ManageProject.Model.Job;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Job.Job
{
    public class JobMethod : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            //获得requestUrl和requestType
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            string jobJson = dataMap.GetString("jobJson");
            var result = JsonConvert.DeserializeObject<SchedulerRequest>(jobJson);

            try
            {
                var resultMsg = string.Empty;
                HttpClient client = new HttpClient();
                //GET请求
                if (result.RequestType == (int)JobEnum.RequestType.Get)
                {
                    resultMsg = client.GetAsync(result.RequestUrl).Result.Content.ReadAsStringAsync().Result;
                }
                //POST请求
                else if (result.RequestType == (int)JobEnum.RequestType.Post)
                {
                    SchedulerRequest re = new SchedulerRequest();
                    var content = JsonConvert.SerializeObject(re);
                    resultMsg = client.PostAsync(result.RequestUrl, new StringContent(content)).Result.Content.ReadAsStringAsync().Result;
                }
                //记录返回信息
                LogWriter.info("ExecuteTime：" + DateTime.Now.ToString() + ";JobName" + result.JobName + ";" + resultMsg);

                //保存结果到数据库
                if (resultMsg.ToUpper().Contains("SUCCESS"))
                {
                    result.LogStatus = (int)JobEnum.LogStatus.SuccessInfo;
                    result.ReturnMsg = "SUCCESS";
                }
                else
                {
                    result.LogStatus = (int)JobEnum.LogStatus.FailedInfo;
                    result.ReturnMsg = "FAIL";
                }
                SchedulerConfigQuery.InsertLog(result);
            }
            catch (Exception ex)
            {
                //设置将自动去除这个任务的触发器,所以这个任务不会再执行 
                //JobExecutionException ex_job = new JobExecutionException(ex);
                //ex_job.UnscheduleAllTriggers = true;
                //保存到数据库
                var message = new LogMessage { MessageKey = "Job-Execute", MessageBody = result, Exception = ex.ToString() };
                LogWriter.error("Execute-Exception:" + ex.ToString());
                result.ReturnMsg = "Execute-Exception";
                result.LogStatus = (int)JobEnum.LogStatus.ExceptInfo;
                SchedulerConfigQuery.InsertLog(result);
            }
        }
    }
}
