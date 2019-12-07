using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DenemeApi.Entities.Concrete
{
   public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public long TckNo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int CountsOfAccounts { get; set; }
       
        public List<Account> Accounts { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CreditScore { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalBalance { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
