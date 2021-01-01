using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model
{
    public class SourceMaterialEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// 素才ID
        /// </summary>
        public string SourceID { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoUrl { get; set; }
        /// <summary>
        /// 广告介绍
        /// </summary>
        public string Introduce { get; set; }
        /// <summary>
        /// 最新更新时间
        /// </summary>
        public string LastUpdateTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 1：使用 0：未使用
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 0：抓取数据 1：用户新增数据
        /// </summary>
        public string DataType { get; set; }
    }
}
