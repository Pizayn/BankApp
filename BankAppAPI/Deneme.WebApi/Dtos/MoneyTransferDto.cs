using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.WebApi.Dtos
{
    public class MoneyTransferDto
    {
        public string AccountNumber { get; set; }
        public decimal Money { get; set; }
    }
}
