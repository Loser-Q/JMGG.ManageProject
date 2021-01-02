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
    public class FinanceInfoQuery
    {
        /// <summary>
        /// 财务信息分页查询
        /// </summary>
        /// <returns></returns>
        public List<FinanceInfoEntity> QueryUserMangeList(FinanceInfoRequest request, out int total)
        {
            total = 0;
            List<FinanceInfoEntity> list = new List<FinanceInfoEntity>();
            StringBuilder sq = new StringBuilder();
            sq.Append(" select * from ( ");
            sq.Append(" select {2} ");
            sq.Append(" from dbo.tblFinanceInfo a with(nolock) ");
            sq.Append(" where {0} ");
            sq.Append(" ) c where {1} ");
            DynamicParameters dp = new DynamicParameters();
            string where_1 = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(request.UserName))
            {
                where_1 += " and a.UserName=@UserName";
                dp.Add("UserName", request.UserName, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.BussinessID))
            {
                where_1 += " and a.BusinessID=@BusinessID";
                dp.Add("BusinessID", request.BussinessID, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.StartTime))
            {
                where_1 += " and a.DayDate>=@StartTime";
                dp.Add("StartTime", Convert.ToDateTime(request.StartTime), DbType.DateTime);
            }
            if (!string.IsNullOrWhiteSpace(request.EndTime))
            {
                where_1 += " and a.DayDate<@EndTime";
                dp.Add("EndTime", Convert.ToDateTime(request.EndTime).AddDays(1), DbType.String);
            }
            dp.Add("PageIndex", request.PageIndex, DbType.Int32, ParameterDirection.Input);
            dp.Add("PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);

            string sql_list = string.Format(sq.ToString(), where_1, " c.Num > (@PageIndex - 1) * @PageSize and c.Num <= @PageIndex * @PageSize", "ROW_NUMBER() over(order by a.CreateTime desc) as Num,* ");

            string sql_count = string.Format(sq.ToString(), where_1, "1=1", "count(0) as nums");

            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                total = conn.Query<int>(sql_count, dp).FirstOrDefault();
                list = conn.Query<FinanceInfoEntity>(sql_list, dp).ToList();
            }
            return list;
        }
    }
}
