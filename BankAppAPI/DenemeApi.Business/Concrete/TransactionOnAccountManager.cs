using DenemeApi.Business.Abstract;
using DenemeApi.DataAccess.Abstract;
using DenemeApi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DenemeApi.Business.Concrete
{
    public class TransactionOnAccountManager : ITransactionOnAccountService
    {
      private  ITransactionOnAccountDal _transactionOnAccountDal;
        public TransactionOnAccountManager(ITransactionOnAccountDal transactionOnAccountDal )
        {
            _transactionOnAccountDal = transactionOnAccountDal;
        }
        public void Add(TransactionOnAccount transactionOnAccount)
        {
            _transactionOnAccountDal.Add(transactionOnAccount);
            
        }

       
        public void Update(TransactionOnAccount transactionOnAccount)
        {
            _transactionOnAccountDal.Update(transactionOnAccount);
        }
    }
}
