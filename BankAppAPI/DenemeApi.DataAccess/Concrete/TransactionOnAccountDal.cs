using DenemeApi.DataAccess.Abstract;
using DenemeApi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DenemeApi.DataAccess.Concrete
{
  public  class TransactionOnAccountDal:Repository<TransactionOnAccount, DenemeContext>, ITransactionOnAccountDal
    {
        
    }
}
