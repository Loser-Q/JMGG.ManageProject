using JMGG.ManageProject.DataAccess;
using JMGG.ManageProject.Model.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Business
{
    public class SchedulerConfigLogic
    {
        private readonly SchedulerConfigDB schedulerDal = new SchedulerConfigDB();

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="QueryScheduler"></param>
        /// <returns></returns>
        public int GetTotalJobCount(SchedulerConfigModel QueryScheduler)
        {
            return schedulerDal.GetTotalJobCount(QueryScheduler);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="QueryScheduler"></param>
        /// <returns></returns>
        public List<SchedulerConfigModel> QueryListByConditionPage(SchedulerConfigModel QueryScheduler)
        {
            return schedulerDal.QueryListByConditionPage(QueryScheduler);
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSchedulerConfig(SchedulerConfigModel model)
        {
            return schedulerDal.AddSchedulerConfig(model);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSchedulerConfig(SchedulerConfigModel model)
        {
            return schedulerDal.UpdateSchedulerConfig(model);
        }

        /// <summary>
        /// 批量更新Job启动状态
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSchedulerConfigStatus(string Ids, SchedulerConfigModel model)
        {
            return schedulerDal.UpdateSchedulerConfigStatus(Ids, model);
        }

        /// <summary>
        /// 判断JobName是否重复
        /// </summary>
        /// <param name="JobName"></param>
        /// <returns></returns>
        public bool JobNameCount(string JobName)
        {
            return schedulerDal.JobNameCount(JobName);
        }


        /// <summary>
        /// 获取日志总记录数
        /// </summary>
        /// <param name="QueryScheduler"></param>
        /// <returns></returns>
        public int GetJobLogCount(SchedulerLogModel QueryScheduler)
        {
            return schedulerDal.GetJobLogCount(QueryScheduler);
        }

        /// <summary>
        /// 获取日志分页数据
        /// </summary>
        /// <param name="QueryScheduler"></param>
        /// <returns></returns>
        public List<SchedulerLogModel> QueryListByLogPage(SchedulerLogModel QueryScheduler)
        {
            return schedulerDal.QueryListByLogPage(QueryScheduler);
        }
    }
}
