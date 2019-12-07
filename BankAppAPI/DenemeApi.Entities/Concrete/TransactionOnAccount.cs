using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DenemeApi.Entities.Concrete
{
  public  class TransactionOnAccount
    {
        public int TransactionOnAccountId { get; set; }

        public string ReceivingAccountId { get; set; }
        public int AccountId { get; set; }

        public string SendingAccountId { get; set; }
        public Account Account { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountOfMoney { get; set; }

        public DateTime TransactionTime { get; set; }

        public string ProcessType { get; set; }
    }
}
