using JMGG.ManageProject.DataAccess.User;
using JMGG.ManageProject.Model;
using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Business
{
    public class UserManageLogic
    {
        private static readonly UseManageQuery userManageQuery = new UseManageQuery();
        private static readonly UseManageCMD userManageCMD = new UseManageCMD();
        public UseManagePageResponse QueryUserListPage(UseManageRequest request)
        {
            int total = 0;
            var pageList = userManageQuery.QueryUserMangeList(request, out total);

            UseManagePageResponse page = new UseManagePageResponse();
            if (pageList != null && pageList.Count > 0)
            {
                page.count = total;
                page.data = pageList.Where(p => p.UserName != "admin").ToList();
                return page;
            }
            return page;
        }

        public BaseResponse InsertUser(UseManageEntity request)
        {
            var userEntity = userManageQuery.QueryUserById(new UseManageRequest { BussinessID = request.BussinessID, UserName = request.UserName });
            if (userEntity != null)
            {
                return new BaseResponse { msg = $"{request.UserName}已经添加，请先删除原账号" };
            }
            var res = userManageCMD.InserUser(request);
            return new BaseResponse
            {
                result = res,
                msg = res ? "成功" : "操作失败"
            };
        }

        public UseManageEntity QueryUserByPassword(UseManageRequest request)
        {
            return userManageQuery.QueryUserByPassword(request);
        }

        public bool DeleteUser(List<int> ids)
        {
            return userManageCMD.DeleteUser(ids);
        }
    }
}
