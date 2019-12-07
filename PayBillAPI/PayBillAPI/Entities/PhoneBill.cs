using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayBillAPI.Entities
{
    public class PhoneBill
    {

        public int Id { get; set; }

        public string SubscriberNo { get; set; }

        public decimal Price { get; set; }
    }
}
