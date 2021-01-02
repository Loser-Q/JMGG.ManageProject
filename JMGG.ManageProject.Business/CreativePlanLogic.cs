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

namespace JMGG.ManageProject.Business
{
    public class CreativePlanLogic
    {
        private static readonly CreativePlanQuery CreativePlanQuery = new CreativePlanQuery();
        public CreativePlanPageResponse QueryUserListPage(CreativePlanRequest request)
        {
            int total = 0;
            var pageList = CreativePlanQuery.QueryCreativePlan(request, out total);

            CreativePlanPageResponse page = new CreativePlanPageResponse();
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
