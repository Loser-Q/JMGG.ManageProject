using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model
{
    /// <summary>
    /// 广告计划
    /// </summary>
    public class AdvertisingPlanEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// 开关
        /// </summary>
        public int Switch { get; set; }
        /// <summary>
        /// 广告计划ID
        /// </summary>
        public string ADPlanID { get; set; }
        /// <summary>
        /// 商家计划ID
        /// </summary>
        public string BusinessPlanID { get; set; }
        /// <summary>
        /// 广告名称
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
        /// ECPMCPC
        /// </summary>
        public string ECPMCPC { get; set; }
        public string ECPMCPM { get; set; }
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

        public DateTime CreateTime { get; set; }

        public string CreateUser { get; set; }
        /// <summary>
        /// 1：删除
        /// </summary>
        public string IsDelete { get; set; }
        /// <summary>
        /// 开关操作传值使用
        /// </summary>
        public string DraftId { get; set; }
        /// <summary>
        /// 开关操作传值使用
        /// </summary>
        public string DraftStatus { get; set; }
    }
}
