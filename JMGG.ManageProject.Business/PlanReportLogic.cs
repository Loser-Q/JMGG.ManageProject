using JMGG.ManageProject.DataAccess;
using JMGG.ManageProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Business
{
    public class PlanReportLogic
    {
        private static readonly PlanReportQuery planQuery = new PlanReportQuery();

        public PlanReportPageResponse QueryPlanRepostListPage(PlanReportRequest request)
        {
            int total = 0;
            var pageList = planQuery.QueryAdPlanReportList(request, out total);

            PlanReportPageResponse page = new PlanReportPageResponse();
            if (pageList != null && pageList.Count > 0)
            {
                page.count = total;
                page.data = pageList;
                return page;
            }
            return page;
        }

    }
}
