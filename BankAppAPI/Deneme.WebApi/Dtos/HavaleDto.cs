using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.WebApi.Dtos
{
    public class HavaleDto
    {
        public string ReceivingAccountId { get; set; }
        public string SendingAccountId { get; set; }
        public decimal Money { get; set; }

    }
}
