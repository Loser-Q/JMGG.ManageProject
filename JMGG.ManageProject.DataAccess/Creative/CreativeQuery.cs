using Dapper;
using JMGG.ManageProject.Model.Creative;
using JMGG.ManageProject.Model.CreativePlan;
using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.DataAccess.Creative
{
    public class CreativeQuery
    {
        public List<CreativeEntity> QueryCreativePlan(CreativeRequest request, out int total)
        {
            total = 0;
            List<CreativeEntity> list = new List<CreativeEntity>();
            StringBuilder sq = new StringBuilder();
            sq.Append(" select * from ( ");
            sq.Append(" select {2} ");
            sq.Append(" from dbo.tblSourceMaterial a with(nolock) ");
            sq.Append(" where {0} ");
            sq.Append(" ) c where {1} ");
            DynamicParameters dp = new DynamicParameters();
            string where_1 = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(request.SourceID))
            {
                where_1 += " and a.SourceID=@SourceID";
                dp.Add("SourceID", request.SourceID, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.Introduce))
            {
                where_1 += " and a.Introduce=@Introduce";
                dp.Add("Introduce", request.Introduce, DbType.String);
            }

            dp.Add("PageIndex", request.PageIndex, DbType.Int32, ParameterDirection.Input);
            dp.Add("PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);

            string sql_list = string.Format(sq.ToString(), where_1, " c.Num > (@PageIndex - 1) * @PageSize and c.Num <= @PageIndex * @PageSize", "ROW_NUMBER() over(order by a.CreateTime desc) as Num,* ");

            string sql_count = string.Format(sq.ToString(), where_1, "1=1", "count(0) as nums");

            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                total = conn.Query<int>(sql_count, dp).FirstOrDefault();
                list = conn.Query<CreativeEntity>(sql_list, dp).ToList();
            }
            return list;
        }
    }
}
