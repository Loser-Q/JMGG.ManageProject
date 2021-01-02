using JMGG.ManageProject.DataAccess.CreativePlan;
using JMGG.ManageProject.DataAccess.User;
using JMGG.ManageProject.Model;
using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JMGG.ManageProject.Model.CreativePlan;
using JMGG.ManageProject.DataAccess.Creative;
using JMGG.ManageProject.Model.Creative;

namespace JMGG.ManageProject.Business
{
    public class CreativeLogic
    {
        private static readonly CreativeQuery CreativePlanQuery = new CreativeQuery();
        public CreativePageResponse QueryUserListPage(CreativeRequest request)
        {
            int total = 0;
            var pageList = CreativePlanQuery.QueryCreativePlan(request, out total);

            CreativePageResponse page = new CreativePageResponse();
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
