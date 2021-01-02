using Dapper;
using JMGG.ManageProject.Model.CreativePlan;
using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.DataAccess.CreativePlan
{
    public class CreativePlanQuery
    {
        public List<CreativePlanEntity> QueryCreativePlan(CreativePlanRequest request, out int total)
        {
            total = 0;
            List<CreativePlanEntity> list = new List<CreativePlanEntity>();
            StringBuilder sq = new StringBuilder();
            sq.Append(" select * from ( ");
            sq.Append(" select {2} ");
            sq.Append(" from dbo.tblAdvertisingPlan a with(nolock) ");
            sq.Append(" where {0} ");
            sq.Append(" ) c where {1} ");
            DynamicParameters dp = new DynamicParameters();
            string where_1 = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(request.ADName))
            {
                where_1 += " and a.ADName=@ADName";
                dp.Add("ADName", request.ADName, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.BusinessPlanID))
            {
                where_1 += " and a.BusinessPlanID=@BusinessPlanID";
                dp.Add("BusinessPlanID", request.BusinessPlanID, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.Status))
            {
                where_1 += " and a.Status=@Status";
                dp.Add("Status", request.Status, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.startLaunchTime))
            {
                where_1 += " and a.LaunchTime>@startLaunchTime";
                dp.Add("startLaunchTime", request.startLaunchTime, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.endLaunchTime))
            {
                where_1 += " and a.LaunchTime<=@endLaunchTime";
                dp.Add("endLaunchTime", request.endLaunchTime, DbType.String);
            }
            if (!request.IsAdmin)
            {
                where_1 += " and a.UserManageId=@UserManageId";
                dp.Add("UserManageId", request.UserManageId, DbType.Int32);
            }
            if (!string.IsNullOrWhiteSpace(request.NewAdPlanID))
            {
                where_1 += " and a.NewAdPlanID=@NewAdPlanID";
                dp.Add("NewAdPlanID", request.NewAdPlanID, DbType.String);
            }
            if (!string.IsNullOrWhiteSpace(request.AdPlanID))
            {
                where_1 += " and a.AdPlanID=@AdPlanID";
                dp.Add("AdPlanID", request.AdPlanID, DbType.String);
            }

            where_1 += " and a.IsDelete=0 ";

            dp.Add("PageIndex", request.PageIndex, DbType.Int32, ParameterDirection.Input);
            dp.Add("PageSize", request.PageSize, DbType.Int32, ParameterDirection.Input);

            string sql_list = string.Format(sq.ToString(), where_1, " c.Num > (@PageIndex - 1) * @PageSize and c.Num <= @PageIndex * @PageSize", "ROW_NUMBER() over(order by a.CreateTime desc) as Num,* ");

            string sql_count = string.Format(sq.ToString(), where_1, "1=1", "count(0) as nums");

            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                total = conn.Query<int>(sql_count, dp).FirstOrDefault();
                list = conn.Query<CreativePlanEntity>(sql_list, dp).ToList();
            }
            return list;
        }

        public CreativePlanEntity QueryCreativePlanById(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("  ");
            sql.Append(" SELECT TOP 1 [Id]  ");
            sql.Append(" ,[Switch]  ");
            sql.Append(" ,[NewAdPlanID]  ");
            sql.Append(" ,[ADPlanID]  ");
            sql.Append(" ,[BusinessPlanID]  ");
            sql.Append(" ,[ADName]  ");
            sql.Append(" ,[DeliveryPoint]  ");
            sql.Append(" ,[BillingMethod]  ");
            sql.Append(" ,[UnitPrice]  ");
            sql.Append(" ,[DayBudget]  ");
            sql.Append(" ,[CTRPV]  ");
            sql.Append(" ,[CRUUV]  ");
            sql.Append(" ,[ECPMCPC]  ");
            sql.Append(" ,[ECPMCPM]  ");
            sql.Append(" ,[LaunchSchedule]  ");
            sql.Append(" ,[LaunchTime]  ");
            sql.Append(" ,[Status]  ");
            sql.Append(" ,[ApprovalReason]  ");
            sql.Append(" ,[SourceType]  ");
            sql.Append(" ,[CreateTime]  ");
            sql.Append(" ,[CreateUser]  ");
            sql.Append(" ,[IsDelete]  ");
            sql.Append(" ,[DraftId]  ");
            sql.Append(" ,[DraftStatus]  ");
            sql.Append(" ,[UserManageId]  ");
            sql.Append(" ,[UserName]  ");
            sql.Append(" ,[BusinessID]  ");
            sql.Append(" ,[NewUnitPrice]  ");
            sql.Append(" ,[NewDayBudget]  ");
            sql.Append(" FROM [dbo].[tblAdvertisingPlan] with(nolock) ");
            sql.Append(" where Id=@Id ");
            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return conn.Query<CreativePlanEntity>(sql.ToString(), new { Id = id }).FirstOrDefault();
            }
        }
    }
}
