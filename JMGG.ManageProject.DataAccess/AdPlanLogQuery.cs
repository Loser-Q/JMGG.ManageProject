using Dapper;
using JMGG.ManageProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.DataAccess
{
    public class AdPlanLogQuery
    {
        /// <summary>
        /// 计划操作日志信息分页查询
        /// </summary>
        /// <returns></returns>
        public List<AdPlanyLogEntity> QueryAdPlanLogList(AdPlanyLogRequest request, out int total)
        {
            total = 0;
            List<AdPlanyLogEntity> list = new List<AdPlanyLogEntity>();
            StringBuilder sq = new StringBuilder();
            sq.Append(" select * from ( ");
            sq.Append(" select {2} ");
            sq.Append(" from dbo.tblAdPlanyLog a with(nolock) ");
            sq.Append(" where {0} ");
            sq.Append(" ) c where {1} ");
            DynamicParameters dp = new DynamicParameters();
            string where_1 = " 1=1 ";

            where_1 += " and a.UserMangeId=@UserMangeId";
            dp.Add("UserMangeId", request.UserName, DbType.String);

            if (!string.IsNullOrWhiteSpace(request.BussinessPlanId))
            {
                where_1 += " and a.BusinessPlanID=@BusinessPlanID";
                dp.Add("BusinessPlanID", request.BussinessID, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.AdPlanId))
            {
                where_1 += " and a.ADPlanID=@ADPlanID";
                dp.Add("ADPlanID", request.AdPlanId, DbType.String);
            }

            dp.Add("PageIndex", request.PageIndex, DbType.Int32, ParameterDirection.Input);
            dp.Add("PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);

            string sql_list = string.Format(sq.ToString(), where_1, " c.Num > (@PageIndex - 1) * @PageSize and c.Num <= @PageIndex * @PageSize", "ROW_NUMBER() over(order by a.CreateTime desc) as Num,* ");

            string sql_count = string.Format(sq.ToString(), where_1, "1=1", "count(0) as nums");

            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                total = conn.Query<int>(sql_count, dp).FirstOrDefault();
                list = conn.Query<AdPlanyLogEntity>(sql_list, dp).ToList();
            }
            return list;
        }
    }
}
