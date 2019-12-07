using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayBillAPI.Entities;

namespace PayBillAPI.Data
{
    public class Bill : IBill
    {
        private BillContext _billContext;
        public Bill(BillContext billContext)
        {
            _billContext = billContext;
        }

        public async Task<PhoneBill> GetFatura(string subscriberNo)
        {
            return await _billContext.PhoneBills.FirstOrDefaultAsync(x => x.SubscriberNo == subscriberNo);
        }

        public bool SubscriberExist(string subscriberNo)
        {
            if (_billContext.PhoneBills.Any(x => x.SubscriberNo == subscriberNo))
            {
                return true;
            }
            return false;
        }

        public  void Update(PhoneBill phoneBill)
        {
           
            _billContext.PhoneBills.Update(phoneBill);
             _billContext.SaveChanges();
        }
     

    }
}
