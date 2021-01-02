using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using JMGG.ManageProject.Model.Creative;

namespace JMGG.ManageProject.DataAccess.User
{
    public class CreativeCMD
    {
        public bool Inser(CreativeEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tblSourceMaterial (");
            strSql.Append("SourceID,VideoUrl,Introduce,LastUpdateTime,CreateTime,Status,DataType)");
            strSql.Append(" values (");
            strSql.Append("@SourceID,@VideoUrl,@Introduce,@LastUpdateTime,@CreateTime,@Status,@DataType)");
            strSql.Append(";select @@IDENTITY");

            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Execute(strSql.ToString(), model) > 0;
            }
        }
       
    }
}
