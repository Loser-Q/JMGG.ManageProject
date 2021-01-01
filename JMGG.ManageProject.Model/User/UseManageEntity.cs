using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model.User
{
    /// <summary>
    ///用户管理页面（后台配置使用）
    /// </summary>
    public class UseManageEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public string BussinessID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }
        /// <summary>
        /// 删除 1:是 0:否
        /// </summary>
        public int IsDelete { get; set; }

        public string UserId { get; set; }
    }

    /// <summary>
    /// 请求类
    /// </summary>
    public class UseManageRequest
    {
        public string BussinessID { get; set; }

        public string UserName { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }

    public class UseManagePageResponse
    {
        public UseManagePageResponse()
        {
            count = 0;
            data = new List<UseManageEntity>();
        }

        public List<UseManageEntity> data { get; set; }

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
