using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayBillAPI.Data;

namespace PayBillAPI.Controllers
{
    [Route("api/payments")]
    [Produces("application/json")]
    public class PaymentsController : ControllerBase
    {
        private IBill _bill;

        public PaymentsController(IBill bill)
        {
            _bill = bill;
        }


        [HttpGet("{subscriberNo}")]
        public async Task<IActionResult> Get(string subscriberNo)
        {
            if (_bill.SubscriberExist(subscriberNo) == false)
            {
                return NoContent();
            }

            var Fatura = await _bill.GetFatura(subscriberNo);

            return Ok(Fatura);

        }
        [HttpGet]
        [Route("okey/{subscriberNo}")]
        public async Task<IActionResult> GetOkey(string subscriberNo)
        {
            if (_bill.SubscriberExist(subscriberNo) == false)
            {
                return NoContent();
            }

            var Fatura = await _bill.GetFatura(subscriberNo);
            Fatura.Price = 0;
            _bill.Update(Fatura);

            return Ok();

        }




    }
}