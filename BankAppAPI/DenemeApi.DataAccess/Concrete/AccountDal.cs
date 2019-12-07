using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DenemeApi.DataAccess.Abstract;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.DataAccess.Concrete
{
   public class AccountDal:Repository<Account,DenemeContext>,IAccountDal
    {
        public int GetAccountCount(int customerId)
        {
            using (DenemeContext context = new DenemeContext())
            {
                var count= context.Accounts.Where(x => x.CustomerId == customerId).Count();
                return count;
            }
        }

        public string GetAccountNumber()
        {
            var number = GetRandomNumber();


            using (DenemeContext context = new DenemeContext())
            {
                if ((context.Accounts.Any(x => x.AccountNumber == number))==false)
                {

                    GetRandomNumber();
                }
            }

            return number;
        }

        private static string GetRandomNumber()
        {
            Random random = new Random();

            
            var number = random.Next(100000000, 999999999).ToString();
            return number;
        }
    }
}
