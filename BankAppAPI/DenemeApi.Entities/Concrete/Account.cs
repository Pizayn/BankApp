using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DenemeApi.Entities.Concrete
{
     public class Account
    {
        public int AccountId { get; set; }

        public int AccountNo { get; set; }

        public bool isActive { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime RegistrationTime { get; set; }
        public List<TransactionOnAccount> TransactionOnAccounts { get; set; }
    }
}
