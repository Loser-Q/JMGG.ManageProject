using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.DataAccess
{
    public class DBConnectionStringConfig
    {
        private static DBConnectionStringConfig _default;

        /// <summary>
        /// 默认配置对象
        /// </summary>
        public static DBConnectionStringConfig Default { get { return _default; } }

        /// <summary>
        /// JMGGConnectionString
        /// </summary>
        public string JMGGConnectionString { get; set; }

        /// <summary>
        /// 初始化配置对象
        /// </summary>
        public static void InitDefault(DBConnectionStringConfig defaultConfig)
        {
            _default = defaultConfig;
        }
    }
}
