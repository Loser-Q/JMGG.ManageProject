using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model
{
    /// <summary>
    /// 财务信息
    /// </summary>
    public class FinanceInfoEntity
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime DayDate { get; set; }
        /// <summary>
        /// 存入多少元（抓取的原数据）
        /// </summary>
        public string DepositMoney { get; set; }
        /// <summary>
        /// 日终结余（抓取的原数据）
        /// </summary>
        public string DayBalance { get; set; }
        /// <summary>
        /// 存入多少元
        /// </summary>
        public string NewDepositMoney { get; set; }
        /// <summary>
        /// 日终结余
        /// </summary>
        public string NewDayBalance { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 用户ID(关联用户UserManage表的ID)
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public string BusinessID { get; set; }
    }

    public class FinanceInfoRequest
    {
        public string BussinessID { get; set; }

        public string UserName { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }

    public class FinanceInfoPageResponse
    {
        public FinanceInfoPageResponse()
        {
            count = 0;
            data = new List<FinanceInfoEntity>();
        }

        public List<FinanceInfoEntity> data { get; set; }

        public int count { get; set; }

        public int code { get; set; }

        public string msg { get; set; }
    }
}
