using JMGG.ManageProject.DataAccess;
using JMGG.ManageProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Business
{
    public class AdPlanLogLogic
    {
        private static readonly AdPlanLogQuery adPlanQuery = new AdPlanLogQuery();
        private static readonly AdPlanLogCMD adPlanCMD = new AdPlanLogCMD();

        public AdPlanyLogPageResponse QueryAdPlanLogListPage(AdPlanyLogRequest request)
        {
            int total = 0;
            var pageList = adPlanQuery.QueryAdPlanLogList(request, out total);

            AdPlanyLogPageResponse page = new AdPlanyLogPageResponse();
            if (pageList != null && pageList.Count > 0)
            {
                page.count = total;
                page.data = pageList;
                return page;
            }
            return page;
        }

        public bool InsertAdPlanLog(AdPlanyLogEntity entity)
        {
            return adPlanCMD.InsertAdPlanLog(entity);
        }
    }
}
