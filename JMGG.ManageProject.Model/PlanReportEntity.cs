using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model
{
    public class PlanReportEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// 本系统生成，展示给客户使用
        /// </summary>
        public string NewAdPlanId { get; set; }
        /// <summary>
        /// 原第统计划ID
        /// </summary>

        public string AdPlanId { get; set; }

        public DateTime LaunchDate { get; set; }

        public string LaunchDateStr { get { return LaunchDate.ToString("yyyy-MM-dd HH:mm:ss"); } }

        public string AdName { get; set; }

        public string LaunchStatus { get; set; }

        public string PV { get; set; }

        public string CPV { get; set; }

        public string CTRPV { get; set; }

        public string UV { get; set; }

        public string CUV { get; set; }

        public string CTRUV { get; set; }

        public string DPV { get; set; }

        public string InstallCount { get; set; }

        public string ActualAmount { get; set; }

        public DateTime CreateTime { get; set; }

        public int UserManageId { get; set; }

        public string UserName { get; set; }

        public string BussinessId { get; set; }
    }

    public class PlanReportRequest
    {
        public int UserManageId { get; set; }

        public string BussinessID { get; set; }

        public string UserName { get; set; }
        /// <summary>
        /// 广告计划ID
        /// </summary>
        public string NewAdPlanId { get; set; }
        /// <summary>
        /// 广告计划名称
        /// </summary>
        public string AdName { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
        /// <summary>
        /// 投放开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 投放结束时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 投放状态 (1:已发布 2:已结束 3:已暂停)
        /// </summary>
        public string LaunchStatus { get; set; }

        public bool IsAmdin { get; set; }
    }

    public class PlanReportPageResponse
    {
        public PlanReportPageResponse()
        {
            count = 0;
            data = new List<PlanReportEntity>();
        }

        public List<PlanReportEntity> data { get; set; }

        public int count { get; set; }

        public int code { get; set; }

        public string msg { get; set; }
    }
}
