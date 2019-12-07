using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.Business.Abstract
{
  public interface IAccountService
  {
      List<Account> GetAll();
      void Add(Account account);
      int GetAccountCount(int customerId);
      string GetAccountNumber();
      List<Account> GetAccountsById(int customerId);
      void Update(Account account);
      Account GetAccountByNumber(string accountNumber);
      Account GetAccountByNo(int accountNo);




    }
}
