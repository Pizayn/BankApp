using System;
using System.Collections.Generic;
using System.Text;
using DenemeApi.Business.Abstract;
using DenemeApi.DataAccess.Abstract;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.Business.Concrete
{
   public class AccountManager:IAccountService
   {
       private IAccountDal _accountDal;

       public AccountManager(IAccountDal accountDal)
       {
           _accountDal = accountDal;
       }

       public List<Account> GetAll()
       {
           return _accountDal.GetList(x=>x.isActive==true);
       }

       public void Add(Account account)
       {

           _accountDal.Add(account);
       }

       public int GetAccountCount(int customerId)
       {
           return _accountDal.GetAccountCount(customerId);
       }

       public string GetAccountNumber()
       {
           return _accountDal.GetAccountNumber();



           
        }

      

       public List<Account> GetAccountsById(int customerId)
       {
           return _accountDal.GetList(x => x.CustomerId == customerId && x.isActive==true);
       }

       public void Update(Account account)
       {
           _accountDal.Update(account);
       }

       Account IAccountService.GetAccountByNumber(string accountNumber)
       {
           return _accountDal.Get(x => x.AccountNumber == accountNumber);
       }

        public Account GetAccountByNo(int accountNo)
        {
            return _accountDal.Get(x => x.AccountNo == accountNo);
        }
    }
}
