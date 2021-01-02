using JMGG.ManageProject.Model.CreativePlan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace JMGG.ManageProject.DataAccess.CreativePlan
{
    public class CreativePlanCMD
    {
        /// <summary>
        /// 更新广告计划
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool UpdateAdPlanById(CreativePlanEntity entity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [dbo].[tblAdvertisingPlan] set Switch=@Switch,NewUnitPrice=@NewUnitPrice,NewDayBudget=@NewDayBudget,Status=@Status,ADPlanID=@ADPlanID where Id = @Id ");
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Execute(strSql.ToString(), entity) > 0;
            }
        }
    }
}
