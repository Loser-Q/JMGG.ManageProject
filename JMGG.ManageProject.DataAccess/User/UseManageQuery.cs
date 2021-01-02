using Dapper;
using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.DataAccess.User
{
    public class UseManageQuery
    {
        /// <summary>
        /// 用户分页查询
        /// </summary>
        /// <returns></returns>
        public List<UseManageEntity> QueryUserMangeList(UseManageRequest request, out int total)
        {
            total = 0;
            List<UseManageEntity> list = new List<UseManageEntity>();
            StringBuilder sq = new StringBuilder();
            sq.Append(" select * from ( ");
            sq.Append(" select {2} ");
            sq.Append(" from dbo.tblUserManage a with(nolock) ");
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
                where_1 += " and a.BussinessID=@BussinessID";
                dp.Add("BussinessID", request.BussinessID, DbType.String);
            }
            where_1 += " and a.IsDelete=0 ";

            dp.Add("PageIndex", request.PageIndex, DbType.Int32, ParameterDirection.Input);
            dp.Add("PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);

            string sql_list = string.Format(sq.ToString(), where_1, " c.Num > (@PageIndex - 1) * @PageSize and c.Num <= @PageIndex * @PageSize", "ROW_NUMBER() over(order by a.CreateTime desc) as Num,* ");

            string sql_count = string.Format(sq.ToString(), where_1, "1=1", "count(0) as nums");

            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                total = conn.Query<int>(sql_count, dp).FirstOrDefault();
                list = conn.Query<UseManageEntity>(sql_list, dp).ToList();
            }
            return list;
        }

        public UseManageEntity QueryUserById(UseManageRequest request)
        {
            string sql = "select [Id],[BussinessID],[UserName],[PassWord],[CreateTime],[CreateUser],[IsDelete],CompanyName from dbo.tblUserManage where  UserName = @UserName and IsDelete=0 ";
            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                 return conn.Query<UseManageEntity>(sql, request).FirstOrDefault();
            }
        }

        public UseManageEntity QueryUserByPassword(UseManageRequest request)
        {
            string sql = "select [Id],[BussinessID],[UserName],[PassWord],[CreateTime],[CreateUser],[IsDelete],CompanyName from dbo.tblUserManage where PassWord = @PassWord and UserName = @UserName and IsDelete=0 ";
            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return conn.Query<UseManageEntity>(sql, request).FirstOrDefault();
            }
        }
    }
}
