using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.WebApi.Dtos
{
    public class TransactionDto
    {
        public string ReceivingAccountId { get; set; }


        public string SendingAccountId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountOfMoney { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionTime { get; set; }

        public string ProcessType { get; set; }
    }
}
