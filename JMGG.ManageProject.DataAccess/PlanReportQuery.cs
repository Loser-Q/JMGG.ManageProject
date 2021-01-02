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
    public class PlanReportQuery
    {
        /// <summary>
        /// 计划操报表信息分页查询
        /// </summary>
        /// <returns></returns>
        public List<PlanReportEntity> QueryAdPlanReportList(PlanReportRequest request, out int total)
        {
            total = 0;
            List<PlanReportEntity> list = new List<PlanReportEntity>();
            StringBuilder sq = new StringBuilder();
            sq.Append(" select * from ( ");
            sq.Append(" select {2} ");
            sq.Append(" from dbo.tblPlanReport a with(nolock) ");
            sq.Append(" where {0} ");
            sq.Append(" ) c where {1} ");
            DynamicParameters dp = new DynamicParameters();
            string where_1 = " 1=1 ";

            if (!request.IsAmdin)
            {
                where_1 += " and a.UserManageId=@UserManageId";
                dp.Add("UserManageId", request.UserManageId, DbType.String);
            }

            if (!string.IsNullOrWhiteSpace(request.StartTime))
            {
                where_1 += " and a.LaunchDate>=@StartTime";
                dp.Add("StartTime", Convert.ToDateTime(Convert.ToDateTime(request.StartTime).ToString("yyyy-MM-dd")), DbType.DateTime);
            }
            if (!string.IsNullOrWhiteSpace(request.EndTime))
            {
                where_1 += " and a.LaunchDate<@EndTime";
                dp.Add("EndTime", Convert.ToDateTime(request.EndTime).AddDays(1), DbType.DateTime);
            }
            if (!string.IsNullOrWhiteSpace(request.NewAdPlanId))
            {
                where_1 += " and a.NewAdPlanId=@NewAdPlanId";
                dp.Add("NewAdPlanId", request.NewAdPlanId, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.AdName))
            {
                where_1 += " and a.AdName=@AdName";
                dp.Add("AdName", request.AdName, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.LaunchStatus))
            {
                where_1 += " and a.LaunchStatus=@LaunchStatus";
                dp.Add("LaunchStatus", request.LaunchStatus, DbType.String);
            }

            dp.Add("PageIndex", request.PageIndex, DbType.Int32, ParameterDirection.Input);
            dp.Add("PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);

            string sql_list = string.Format(sq.ToString(), where_1, " c.Num > (@PageIndex - 1) * @PageSize and c.Num <= @PageIndex * @PageSize", "ROW_NUMBER() over(order by a.CreateTime desc) as Num,* ");

            string sql_count = string.Format(sq.ToString(), where_1, "1=1", "count(0) as nums");

            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                total = conn.Query<int>(sql_count, dp).FirstOrDefault();
                list = conn.Query<PlanReportEntity>(sql_list, dp).ToList();
            }
            return list;
        }
    }
}
