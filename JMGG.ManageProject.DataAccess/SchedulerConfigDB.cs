using Dapper;
using JMGG.ManageProject.Model.Job;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.DataAccess
{
    public class SchedulerConfigDB
    {
        /// <summary>
        ///  获取总记录数
        /// </summary>
        /// <param name="QueryCondition"></param>
        /// <returns></returns>
        public int GetTotalJobCount(SchedulerConfigModel QueryScheduler)
        {
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                DynamicParameters dp = new DynamicParameters();

                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append(" SELECT COUNT(1) FROM SchedulerConfig rclf WITH(NOLOCK) WHERE 1=1 ");
                if (!string.IsNullOrEmpty(QueryScheduler.JobGroup))
                {
                    sqlQuery.Append(" AND rclf.JobGroup=@JobGroup ");
                    dp.Add("@JobGroup", QueryScheduler.JobGroup, DbType.String, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(QueryScheduler.JobName))
                {
                    sqlQuery.Append(" AND rclf.JobName=@JobName ");
                    dp.Add("@JobName", QueryScheduler.JobName, DbType.String, ParameterDirection.Input);
                }
                if (QueryScheduler.RequestType == 1 || QueryScheduler.RequestType == 2)
                {
                    sqlQuery.Append(" AND rclf.RequestType=@RequestType ");
                    dp.Add("@RequestType", QueryScheduler.RequestType, DbType.Int32, ParameterDirection.Input);
                }
                if (QueryScheduler.IsEnable == 0 || QueryScheduler.IsEnable == 1)
                {
                    sqlQuery.Append(" AND rclf.IsEnable=@IsEnable ");
                    dp.Add("@IsEnable", QueryScheduler.IsEnable, DbType.Int32, ParameterDirection.Input);
                }
                if (QueryScheduler.StartTime != DateTime.MinValue && QueryScheduler.StartTime != null)
                {
                    sqlQuery.Append(" AND rclf.CreateTime>=@StartTime ");
                    dp.Add("@StartTime", QueryScheduler.StartTime, DbType.String, ParameterDirection.Input);
                }
                if (QueryScheduler.EndTime != DateTime.MinValue && QueryScheduler.EndTime != null)
                {
                    sqlQuery.Append(" AND rclf.CreateTime<=@EndTime ");
                    dp.Add("@EndTime", Convert.ToDateTime(Convert.ToDateTime(QueryScheduler.EndTime).ToString("yyyy-MM-dd") + " 23:59:59"), DbType.String, ParameterDirection.Input);
                }

                return connection.ExecuteScalar<int>(sqlQuery.ToString(), dp);
            }
        }


        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="QueryCondition"></param>
        /// <returns></returns>
        public List<SchedulerConfigModel> QueryListByConditionPage(SchedulerConfigModel QueryScheduler)
        {
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                DynamicParameters dp = new DynamicParameters();

                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append(" SELECT * ");
                sqlQuery.Append(" FROM SchedulerConfig rclf WITH(NOLOCK) WHERE 1=1 ");
                if (!string.IsNullOrEmpty(QueryScheduler.JobGroup))
                {
                    sqlQuery.Append(" AND rclf.JobGroup=@JobGroup ");
                    dp.Add("@JobGroup", QueryScheduler.JobGroup, DbType.String, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(QueryScheduler.JobName))
                {
                    sqlQuery.Append(" AND rclf.JobName=@JobName ");
                    dp.Add("@JobName", QueryScheduler.JobName, DbType.String, ParameterDirection.Input);
                }
                if (QueryScheduler.RequestType == 1 || QueryScheduler.RequestType == 2)
                {
                    sqlQuery.Append(" AND rclf.RequestType=@RequestType ");
                    dp.Add("@RequestType", QueryScheduler.RequestType, DbType.Int32, ParameterDirection.Input);
                }
                if (QueryScheduler.IsEnable == 0 || QueryScheduler.IsEnable == 1)
                {
                    sqlQuery.Append(" AND rclf.IsEnable=@IsEnable ");
                    dp.Add("@IsEnable", QueryScheduler.IsEnable, DbType.Int32, ParameterDirection.Input);
                }
                if (QueryScheduler.StartTime != DateTime.MinValue && QueryScheduler.StartTime != null)
                {
                    sqlQuery.Append(" AND rclf.CreateTime>=@StartTime ");
                    dp.Add("@StartTime", QueryScheduler.StartTime, DbType.DateTime, ParameterDirection.Input);
                }
                if (QueryScheduler.EndTime != DateTime.MinValue && QueryScheduler.EndTime != null)
                {
                    sqlQuery.Append(" AND rclf.CreateTime<=@EndTime ");
                    dp.Add("@EndTime", Convert.ToDateTime(Convert.ToDateTime(QueryScheduler.EndTime).ToString("yyyy-MM-dd") + " 23:59:59"), DbType.DateTime, ParameterDirection.Input);
                }

                sqlQuery.Append(" ORDER BY rclf.ID DESC ");
                sqlQuery.Append(" OFFSET (@PageSize * (@PageIndex -1)) ROWS FETCH NEXT @PageSize ROWS ONLY ");

                dp.Add("@PageSize", QueryScheduler.PageSize, DbType.Int32, ParameterDirection.Input);
                dp.Add("@PageIndex", QueryScheduler.PageIndex, DbType.Int32, ParameterDirection.Input);
                return connection.Query<SchedulerConfigModel>(sqlQuery.ToString(), dp).ToList();
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSchedulerConfig(SchedulerConfigModel model)
        {
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" INSERT INTO SchedulerConfig ");
                sb.Append(" (JobGroup,JobName,RequestType,RequestUrl,CronTab,JobRemark,CreateUser, ");
                sb.Append("  LastUpdateUser,IsEnable,Status, StartTime, EndTime) ");
                sb.Append(" VALUES ");
                sb.Append(" (@JobGroup,@JobName,@RequestType,@RequestUrl,@CronTab,@JobRemark,@CreateUser,@LastUpdateUser,");
                sb.Append("  @IsEnable,@Status,@StartTime,@EndTime); ");
                sb.Append(" SELECT CAST(SCOPE_IDENTITY() AS INT) ");
                sb.Append(" ");
                model.ID = connection.Query<int>(sb.ToString(), model).Single();
                return model.ID;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSchedulerConfig(SchedulerConfigModel model)
        {
            StringBuilder strSql = new StringBuilder();
            DynamicParameters dp = new DynamicParameters();
            strSql.Append(" UPDATE SchedulerConfig SET ");
            strSql.Append(" JobGroup=@JobGroup, ");
            strSql.Append(" JobName=@JobName, ");
            strSql.Append(" RequestType=@RequestType, ");
            strSql.Append(" RequestUrl=@RequestUrl, ");
            strSql.Append(" CronTab=@CronTab, ");
            strSql.Append(" JobRemark=@JobRemark, ");
            strSql.Append(" LastUpdateTime=@LastUpdateTime, ");
            strSql.Append(" LastUpdateUser=@LastUpdateUser, ");
            strSql.Append(" StartTime=@StartTime, ");
            strSql.Append(" EndTime=@EndTime, ");
            strSql.Append(" Status=@Status ");
            strSql.Append(" WHERE ID=@ID ");
            dp.Add("@JobGroup", model.JobGroup, DbType.String, ParameterDirection.Input);
            dp.Add("@JobName", model.JobName, DbType.String, ParameterDirection.Input);
            dp.Add("@RequestType", model.RequestType, DbType.Int32, ParameterDirection.Input);
            dp.Add("@RequestUrl", model.RequestUrl, DbType.String, ParameterDirection.Input);
            dp.Add("@CronTab", model.CronTab, DbType.String, ParameterDirection.Input);
            dp.Add("@JobRemark", model.JobRemark, DbType.String, ParameterDirection.Input);
            dp.Add("@LastUpdateTime", model.LastUpdateTime, DbType.DateTime, ParameterDirection.Input);
            dp.Add("@LastUpdateUser", model.LastUpdateUser, DbType.String, ParameterDirection.Input);
            dp.Add("@StartTime", model.StartTime, DbType.String, ParameterDirection.Input);
            dp.Add("@EndTime", model.EndTime, DbType.String, ParameterDirection.Input);
            dp.Add("@ID", model.ID, DbType.Int32, ParameterDirection.Input);
            dp.Add("@Status", model.Status, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Execute(strSql.ToString(), dp) > 0;
            }
        }

        /// <summary>
        /// 批量更新Job启动状态
        /// </summary>
        /// <param name="Ids"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSchedulerConfigStatus(string Ids, SchedulerConfigModel model)
        {
            StringBuilder strSql = new StringBuilder();
            DynamicParameters dp = new DynamicParameters();
            strSql.Append(" UPDATE SchedulerConfig SET ");
            strSql.Append(" IsEnable=@IsEnable, ");
            strSql.Append(" Status=@Status, ");
            strSql.Append(" LastUpdateUser=@LastUpdateUser, ");
            strSql.Append(" LastUpdateTime=@LastUpdateTime ");
            strSql.Append(" WHERE ID IN (" + Ids + ") ");
            //禁用
            if (model.IsEnable == 0)
            {
                strSql.Append(" AND IsEnable=1 ");
            }
            //启用
            if (model.IsEnable == 1)
            {
                strSql.Append(" AND IsEnable=0 ");
            }
            dp.Add("@IsEnable", model.IsEnable, DbType.Int32, ParameterDirection.Input);
            dp.Add("@Status", model.Status, DbType.Int32, ParameterDirection.Input);
            dp.Add("@LastUpdateTime", model.LastUpdateTime, DbType.DateTime, ParameterDirection.Input);
            dp.Add("@LastUpdateUser", model.LastUpdateUser, DbType.String, ParameterDirection.Input);
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                return connection.Execute(strSql.ToString(), dp) > 0;
            }
        }

        /// <summary>
        /// 判断JobName是否重复
        /// </summary>
        /// <param name="JobName"></param>
        /// <returns></returns>
        public bool JobNameCount(string JobName)
        {
            var flag = false;
            DynamicParameters dp = new DynamicParameters();

            string sql = "SELECT COUNT(*) FROM SchedulerConfig WHERE JobName=@JobName ";
            dp.Add("@JobName", JobName, DbType.String, ParameterDirection.Input);

            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                var obj = connection.ExecuteScalar(sql, dp);
                if (obj != null)
                {
                    flag = Convert.ToInt32(obj) > 0;
                }
            }
            return flag;
        }


        /// <summary>
        ///  获取日志总记录数
        /// </summary>
        /// <param name="QueryCondition"></param>
        /// <returns></returns>
        public int GetJobLogCount(SchedulerLogModel logModel)
        {
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                DynamicParameters dp = new DynamicParameters();

                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append(" SELECT COUNT(1) FROM SchedulerLog rclf WITH(NOLOCK) WHERE 1=1 ");
                if (logModel.Status >= 0)
                {
                    sqlQuery.Append(" AND rclf.Status=@Status ");
                    dp.Add("@Status", logModel.Status, DbType.Int32, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(logModel.JobName))
                {
                    sqlQuery.Append(" AND rclf.JobName=@JobName ");
                    dp.Add("@JobName", logModel.JobName, DbType.String, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(logModel.StartTime))
                {
                    sqlQuery.Append(" AND rclf.CreateTime>=@StartTime ");
                    dp.Add("@StartTime", logModel.StartTime, DbType.String, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(logModel.EndTime))
                {
                    sqlQuery.Append(" AND rclf.CreateTime<=@EndTime ");
                    dp.Add("@EndTime", logModel.EndTime, DbType.String, ParameterDirection.Input);
                }

                return connection.ExecuteScalar<int>(sqlQuery.ToString(), dp);
            }
        }


        /// <summary>
        /// 获取日志分页数据
        /// </summary>
        /// <param name="QueryCondition"></param>
        /// <returns></returns>
        public List<SchedulerLogModel> QueryListByLogPage(SchedulerLogModel logModel)
        {
            using (IDbConnection connection = new SqlConnection(DBConnectionStringConfig.Default.JMGGConnectionString))
            {
                DynamicParameters dp = new DynamicParameters();

                StringBuilder sqlQuery = new StringBuilder();
                sqlQuery.Append(" SELECT * FROM SchedulerLog rclf WITH(NOLOCK) WHERE 1=1 ");
                if (logModel.Status >= 0)
                {
                    sqlQuery.Append(" AND rclf.Status=@Status ");
                    dp.Add("@Status", logModel.Status, DbType.Int32, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(logModel.JobName))
                {
                    sqlQuery.Append(" AND rclf.JobName=@JobName ");
                    dp.Add("@JobName", logModel.JobName, DbType.String, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(logModel.StartTime))
                {
                    sqlQuery.Append(" AND rclf.CreateTime>=@StartTime ");
                    dp.Add("@StartTime", logModel.StartTime, DbType.String, ParameterDirection.Input);
                }
                if (!string.IsNullOrEmpty(logModel.EndTime))
                {
                    sqlQuery.Append(" AND rclf.CreateTime<=@EndTime ");
                    dp.Add("@EndTime", logModel.EndTime, DbType.String, ParameterDirection.Input);
                }

                sqlQuery.Append(" ORDER BY rclf.ID DESC ");
                sqlQuery.Append(" OFFSET (@PageSize * (@PageIndex -1)) ROWS FETCH NEXT @PageSize ROWS ONLY ");

                dp.Add("@PageSize", logModel.PageSize, DbType.Int32, ParameterDirection.Input);
                dp.Add("@PageIndex", logModel.PageIndex, DbType.Int32, ParameterDirection.Input);
                return connection.Query<SchedulerLogModel>(sqlQuery.ToString(), dp).ToList();
            }
        }
    }
}
