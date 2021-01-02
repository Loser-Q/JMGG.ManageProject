using JMGG.ManageProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace JMGG.ManageProject.DataAccess
{
    public class AdPlanLogCMD
    {
        public bool InsertAdPlanLog(AdPlanyLogEntity entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" insert into [dbo].[tblAdPlanyLog] ( ");
            strSql.Append("   [UserMangeId] ");
            strSql.Append("  ,[UserName] ");
            strSql.Append("  ,[BusinessId] ");
            strSql.Append("  ,[BusinessPlanID] ");
            strSql.Append("  ,[ADPlanID] ");
            strSql.Append("  ,[ADName] ");
            strSql.Append("  ,[BillingMethod] ");
            strSql.Append("  ,[OperationType] ");
            strSql.Append("  ,[OldJson] ");
            strSql.Append("  ,[NewJson] ");
            strSql.Append("  ,[CreateUser] ");
            strSql.Append("  ) values( ");
            strSql.Append("   @UserMangeId ");
            strSql.Append("  ,@UserName ");
            strSql.Append("  ,@BusinessId ");
            strSql.Append("  ,@BusinessPlanID ");
            strSql.Append("  ,@ADPlanID ");
            strSql.Append("  ,@ADName ");
            strSql.Append("  ,@BillingMethod ");
            strSql.Append("  ,@OperationType ");
            strSql.Append("  ,@OldJson ");
            strSql.Append("  ,@NewJson ");
            strSql.Append("  ,@CreateUser ");
            strSql.Append("  )");
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Execute(strSql.ToString(), entity) > 0;
            }
        }
    }
}
