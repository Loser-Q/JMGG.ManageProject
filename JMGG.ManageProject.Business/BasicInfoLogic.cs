using JMGG.ManageProject.DataAccess.BasicInfo;
using JMGG.ManageProject.DataAccess.User;
using JMGG.ManageProject.Model;
using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JMGG.ManageProject.Model.BasicInfo;

namespace JMGG.ManageProject.Business
{
    public class BasicInfoLogic
    {
        private static readonly BasicInfoQuery basicInfoQuery = new BasicInfoQuery();
        public BasicInfoPageResponse QueryUserListPage(BasicInfoRequest request)
        {
            int total = 0;
            var pageList = basicInfoQuery.QueryBasicInfo(request, out total);

            BasicInfoPageResponse page = new BasicInfoPageResponse();
            if (pageList != null && pageList.Count > 0)
            {
                page.count = total;
                page.data = pageList.ToList();
                return page;
            }
            return page;
        }
   
    }
}
