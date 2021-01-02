using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model.CreativePlan
{
    /// <summary>
    ///用户管理页面（后台配置使用）
    /// </summary>
    public class CreativePlanEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// 开关 1：开  2：关
        /// </summary>
        public string Switch { get; set; }
        /// <summary>
        /// 广告计划ID
        /// </summary>
        public string ADPlanID { get; set; }
        /// <summary>
        /// 商家计划ID
        /// </summary>
        public string BusinessPlanID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ADName { get; set; }
        /// <summary>
        /// 投放点位
        /// </summary>
        public string DeliveryPoint { get; set; }

        /// <summary>
        /// 计费方式
        /// </summary>
        public string BillingMethod { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// 单日
        /// </summary>
        public string DayBudget { get; set; }

        /// <summary>
        /// CTRPV
        /// </summary>
        public string CTRPV { get; set; }

        /// <summary>
        /// CRUUV
        /// </summary>
        public string CRUUV { get; set; }

        /// <summary>
        /// 投放排期
        /// </summary>
        public string LaunchSchedule { get; set; }
        /// <summary>
        /// 投放时段
        /// </summary>
        public string LaunchTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 审核原因
        /// </summary>
        public string ApprovalReason { get; set; }
        /// <summary>
        /// 1;抓取数据 2：用户新增数据
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public string CreateTimeStr { get { return CreateTime.ToString("yyyy-MM-dd HH:mm:ss"); } }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 删除 1:是 0:否
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 开关操作传值使用
        /// </summary>
        public string DraftId { get; set; }
        /// <summary>
        /// 开关操作传值使用
        /// </summary>
        public string DraftStatus { get; set; }
    }

    /// <summary>
    /// 请求类
    /// </summary>
    public class CreativePlanRequest
    {
        public string ADName { get; set; }

        public string BusinessPlanID { get; set; }

        public string startLaunchTime { get; set; }
        public string endLaunchTime { get; set; }

        public string Status { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }

    public class CreativePlanPageResponse
    {
        public CreativePlanPageResponse()
        {
            count = 0;
            data = new List<CreativePlanEntity>();
        }

        public List<CreativePlanEntity> data { get; set; }

        public int count { get; set; }

        public int code { get; set; }

        public string msg { get; set; }

        ///// <summary>
        ///// 总数目
        ///// </summary>
        //public int total { get; set; }

        ///// <summary>
        ///// 每页行数
        ///// </summary>
        //public List<UseManageEntity> rows { get; set; }
    }
}
