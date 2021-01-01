using log4net;
using Quartz;
using Quartz.Impl;
using System;

namespace JMGG.ManageProject.Common
{
    public class SchedulerHelper
    {
        ILog log = LogManager.GetLogger(typeof(SchedulerHelper));

        private readonly IScheduler scheduler;
        public SchedulerHelper()
        {
            ISchedulerFactory sf = new StdSchedulerFactory();
            try
            {
                scheduler = (IScheduler)sf.GetScheduler();
            }
            catch (SchedulerException e)
            {
                log.Error("创建调度对象异常：" + e.ToString());
            }
        }

        /// <summary>
        /// 关闭调度信息
        /// </summary>
        public void shutdown()
        {
            scheduler.Shutdown(false);
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void PauseAll()
        {
            scheduler.PauseAll();
        }

        /// <summary>
        /// 恢复
        /// </summary>
        public void ResumeAll()
        {
            scheduler.ResumeAll();
        }

        /// <summary>
        /// 添加调度的job信息 
        /// </summary>
        /// <param name="jobdetail">Job信息</param>
        /// <param name="trigger">触发器信息</param>
        /// <returns></returns>
        public DateTimeOffset scheduleJob(IJobDetail jobdetail, ITrigger trigger)
        {
            scheduler.Start();
            return scheduler.ScheduleJob(jobdetail, trigger);
        }

        /// <summary>
        /// 判断Job是否存在，存在并删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool IsExistsDelJob(string JobName, string JobGroup)
        {

            TriggerKey tkey = new TriggerKey(JobName + "Trigger", JobGroup + "Trigger");
            if (scheduler.CheckExists(tkey))
            {
                //1.停止触发器
                scheduler.PauseTrigger(tkey);
                //2.移除触发器
                scheduler.UnscheduleJob(tkey);
            }
            //3.删除任务
            var result = true;
            JobKey key = new JobKey(JobName, JobGroup);
            if (scheduler.CheckExists(key))
                result = scheduler.DeleteJob(key);
            return result;
        }
    }
}
