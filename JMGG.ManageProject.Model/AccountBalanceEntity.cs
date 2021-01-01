using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model
{
    public class AccountBalanceEntity
    {
        public int Id { get; set; }

        public string UserId { get; set; }
       
        public string UserName { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 账户总余额(元)  抓取的数据
        /// </summary>
        public string AccountTotalBalance { get; set; }
        /// <summary>
        /// 今日账户消耗(元) 抓取的数据
        /// </summary>
        public string AccountConsumeBalance { get; set; }

        public string NewAccountTotalBalance { get; set; }

        public string NewAccountConsumeBalance { get; set; }

        public string CreateTime { get; set; }
    }
}
