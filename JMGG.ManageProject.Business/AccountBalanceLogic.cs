using JMGG.ManageProject.DataAccess;
using JMGG.ManageProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMGG.ManageProject.Business
{
    public class AccountBalanceLogic
    {
        AccountBalanceQuery query = new AccountBalanceQuery();

        public AccountBalanceEntity QueryBalanceByUserId(AccountBalanceEntity request)
        {
            return query.QueryBalanceByUserId(request);
        }
    }
}
