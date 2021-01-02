using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model.User
{
    public class UserInfo
    {
        public string Id { get; set; }
        /// <summary>
        /// UserManage关联的ID
        /// </summary>
        public int UserManageId { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public string BussinessID { get; set; }
        /// <summary>
        /// 代理商ID
        /// </summary>
        public string AgentId { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 网站链接
        /// </summary>
        public string WebSite { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }  
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
       
        /// <summary>
        /// 资质信息Json
        /// </summary>
        public string BizInfoJson { get; set; }

        /// <summary>
        /// 资质信息
        /// </summary>
        public BizInfoEntity BizInfo { get; set; }

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

    /// <summary>
    /// 资质信息
    /// </summary>
    public class BizInfoEntity
    {
        #region 属性

        /// <summary>
        /// 营业执照信息
        /// </summary>
        public List<LicenseEntity> LicenseInfoList { get; set; }

        /// <summary>
        /// ICP资质备案信息
        /// </summary>
        public List<IcpInfoEntity> IcpInfoList { get; set; }

        #endregion
    }

    /// <summary>
    /// 营业执照信息
    /// </summary>
    public class LicenseEntity
    {
        #region 属性

        /// <summary>
        /// 营业执照(图片地址)
        /// </summary>
        public string BizPicUrl { get; set; }
        /// <summary>
        /// 营业执照(图片地址)
        /// </summary>
        public string CreditCode { get; set; }

        /// <summary>
        /// 资质到期日期
        /// </summary>
        public string ExpirationDate { get; set; }

        #endregion
    }
    /// <summary>
    /// ICP资质备案信息
    /// </summary>
    public class IcpInfoEntity
    {
        #region 属性

        /// <summary>
        /// 营业执照(图片地址)
        /// </summary>
        public string BizPicUrl { get; set; }

        /// <summary>
        /// 资质到期日期
        /// </summary>
        public string ExpirationDate { get; set; }

        #endregion
    }

    public class LoginInfo
    {
        public int UserManageID { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public string BusinessID { get; set; }
    }
}
