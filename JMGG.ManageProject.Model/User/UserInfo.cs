using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model.User
{
    public class UserInfo
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        public string BussinessID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// 代理商ID
        /// </summary>
        public string AgentId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 营业执照
        /// </summary>
        public string BusinessHeat { get; set; }
        /// <summary>
        /// 资质备案1
        /// </summary>
        public string QualificationUrl1 { get; set; }
        /// <summary>
        /// 资质备案2
        /// </summary>
        public string QualificationUrl2 { get; set; }
        /// <summary>
        /// 资质备案3
        /// </summary>
        public string QualificationUrl3 { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 账号状态
        /// </summary>
        public string AccountStatus { get; set; }
    }

    public class LoginInfo
    {
        public int UserManageID { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public string BusinessID { get; set; }
    }
}
