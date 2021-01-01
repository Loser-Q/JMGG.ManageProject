using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model
{
    public class FinanceInfoEntity
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string DayDate { get; set; }
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
    }
}
