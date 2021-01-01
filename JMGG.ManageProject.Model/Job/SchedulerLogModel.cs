using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model.Job
{
    public class SchedulerLogModel
    {
        public int ID { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string ReturnMsg { get; set; }
        /// <summary>
        /// 数据状态 0成功 1失败 2异常
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>

        public string CreateTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Job组别
        /// </summary>
        public string JobGroup { get; set; }
        /// <summary>
        /// Job名称
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 请求方式
        /// </summary>
        public string RequestType { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
    }
}
