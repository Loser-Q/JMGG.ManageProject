using JMGG.ManageProject.DataAccess.User;
using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Business
{
    public class UserLogic
    {
        private static UserInfoQuery userQuery = new UserInfoQuery();

        public UserInfo QueryUserInfoByAccount(UserInfo request)
        {
            return userQuery.QueryUserInfoByAccount(request);
        }
        public UserInfo QueryUserInfoByBusinessID(UserInfo request)
        {
            
            return userQuery.QueryUserInfoByBusinessID(request);
        }
    }
}
