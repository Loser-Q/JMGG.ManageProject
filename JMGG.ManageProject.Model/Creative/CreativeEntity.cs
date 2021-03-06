﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Model.Creative

{
    /// <summary>
    /// 广告素材
    /// </summary>
    public class CreativeEntity
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
        public string Status { get; set; }

        /// <summary>
        /// 0：抓取数据 1：用户新增数据
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 用户ID(关联用户UserManage表的ID)
        /// </summary>
        public int UserManageId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 商户ID
        /// </summary>
        public string BusinessID { get; set; }
    }

    /// <summary>
    /// 请求类
    /// </summary>
    public class CreativeRequest
    {
        public string SourceID { get; set; }

        public string Introduce { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int UserManageId { get; set; }
    }

    public class CreativePageResponse
    {
        public CreativePageResponse()
        {
            count = 0;
            data = new List<CreativeEntity>();
        }

        public List<CreativeEntity> data { get; set; }

        public int count { get; set; }

        public int code { get; set; }

        public string msg { get; set; }
    }
}
