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
    public class UserInfoQuery
    {
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserInfo QueryUserInfoByAccount(UserInfo request)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top 1 [Id],[BussinessID],[CompanyName],[Mobile],[Password],[Address],[Contacts],[CreateUser],[CreateTime]  FROM dbo.tblUserInfo with(nolock) ");
            strSql.Append(" where 1=1  ");
            DynamicParameters dp = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(request.Mobile))
            {
                strSql.Append(" and Mobile=@Mobile ");
                dp.Add("Mobile", request.Mobile);
            }
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                strSql.Append(" and Password=@Password ");
                dp.Add("Password", request.Password);
            }
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Query<UserInfo>(strSql.ToString(), dp).FirstOrDefault();
            }
        }

        public UserInfo QueryUserInfoByBusinessID(UserInfo request)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT top 1 BussinessID,AccountStatus,CompanyName,Mobile,Password,Address,Contacts,CreateUser,CreateTime,AgentId,ProductId,Email,BusinessHeat,QualificationUrl1,QualificationUrl2,QualificationUrl3  FROM dbo.tblUserInfo with(nolock) ");
            strSql.Append(" where 1=1  ");
            DynamicParameters dp = new DynamicParameters();
            if (!string.IsNullOrWhiteSpace(request.BussinessID))
            {
                strSql.Append(" and BussinessID=@BussinessID ");
                dp.Add("BussinessID", request.BussinessID);
            }
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Query<UserInfo>(strSql.ToString(), dp).FirstOrDefault();
            }
        }
    }
}
