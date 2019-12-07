using PayBillAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayBillAPI.Data
{
    public interface IBill
    {
        Task<PhoneBill> GetFatura(string subscriberNo);

        void Update(PhoneBill phoneBill);

        bool SubscriberExist(string subscriberNo);
    }
}
