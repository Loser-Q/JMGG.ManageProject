using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model
{
    public class AdPlanyLogEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// UserMange表ID
        /// </summary>
        public int UserMangeId { get; set; }

        public string UserName { get; set; }

        public string BusinessId { get; set; }
        /// <summary>
        /// 商家计划ID
        /// </summary>
        public string BusinessPlanID { get; set; }
        /// <summary>
        /// 广告计划ID
        /// </summary>
        public string ADPlanID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string ADName { get; set; }
        /// <summary>
        /// 计费方式
        /// </summary>
        public string BillingMethod { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperationType { get; set; }
        /// <summary>
        /// 操作前
        /// </summary>
        public string OldJson { get; set; }
        /// <summary>
        /// 操作后
        /// </summary>
        public string NewJson { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public string CreateUser { get; set; }

        public string CreateTimeStr { get { return CreateTime.ToString("yyyy-MM-dd HH:mm:ss"); } }
    }

    public class AdPlanyLogRequest
    {
        public int UserManageId { get; set; }

        public string BussinessID { get; set; }

        public string UserName { get; set; }
        /// <summary>
        /// 商家计划ID
        /// </summary>
        public string BussinessPlanId { get; set; }
        /// <summary>
        /// 广告计划ID
        /// </summary>
        public string AdPlanId { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin { get; set; }
    }

    public class AdPlanyLogPageResponse
    {
        public AdPlanyLogPageResponse()
        {
            count = 0;
            data = new List<AdPlanyLogEntity>();
        }

        public List<AdPlanyLogEntity> data { get; set; }

        public int count { get; set; }

        public int code { get; set; }

        public string msg { get; set; }
    }
}
