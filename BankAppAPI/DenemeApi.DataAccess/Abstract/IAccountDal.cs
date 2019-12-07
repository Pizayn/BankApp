using System;
using System.Collections.Generic;
using System.Text;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.DataAccess.Abstract
{
 public   interface IAccountDal:IRepository<Account>
 {
     int GetAccountCount(int customerId);
     string GetAccountNumber();
 }
}
