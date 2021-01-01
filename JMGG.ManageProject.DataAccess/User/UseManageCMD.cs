using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace JMGG.ManageProject.DataAccess.User
{
    public class UseManageCMD
    {
        public bool InserUser(UseManageEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tblUserManage (");
            strSql.Append("BussinessID,UserName,PassWord,CreateTime,CreateUser,IsDelete)");
            strSql.Append(" values (");
            strSql.Append("@BussinessID,@UserName,@PassWord,@CreateTime,@CreateUser,@IsDelete)");
            strSql.Append(";select @@IDENTITY");

            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Execute(strSql.ToString(), model) > 0;
            }
        }

        public bool DeleteUser(List<int> ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [dbo].[tblUserManage] set IsDelete=1 where Id in @ids ");
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Execute(strSql.ToString(), new { ids = ids.ToArray() }) > 0;
            }
        }
    }
}
