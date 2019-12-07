using DenemeApi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DenemeApi.Business.Abstract
{
  public  interface ITransactionOnAccountService
    {

        void Add(TransactionOnAccount transactionOnAccount);
        void Update(TransactionOnAccount transactionOnAccount);

    }
}
