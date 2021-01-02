using JMGG.ManageProject.DataAccess;
using JMGG.ManageProject.Model;
using JMGG.ManageProject.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Business
{
    public class FinanceInfoLogic
    {
        private static readonly FinanceInfoQuery financeQuery = new FinanceInfoQuery();

        /// <summary>
        /// 获取财务分页数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public FinanceInfoPageResponse QueryFinanceListPage(FinanceInfoRequest request)
        {
            int total = 0;
            var pageList = financeQuery.QueryUserMangeList(request, out total);

            FinanceInfoPageResponse page = new FinanceInfoPageResponse();
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
