using JMGG.ManageProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace JMGG.ManageProject.DataAccess
{
    public class AccountBalanceQuery
    {
        public AccountBalanceEntity QueryBalanceByUserId(AccountBalanceEntity request)
        {
            string sql = " select [Id],[UserId],[UserName],[BusinessId],[AccountTotalBalance],[AccountConsumeBalance],[NewAccountTotalBalance],[NewAccountConsumeBalance],[CreateTime] from [dbo].[tblAccountBalance] where BusinessId = @BusinessId and UserName = @UserName ";
            using (IDbConnection conn = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return conn.Query<AccountBalanceEntity>(sql, request).FirstOrDefault();
            }
        }
    }
}
