using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using Deneme.WebApi.Dtos;
using DenemeApi.Business.Abstract;
using DenemeApi.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private IAccountService _accountService;
        private ICustomerService _customerService;
       private  ITransactionOnAccountService _transactionOnAccountService;

        public AccountsController(IAccountService accountService, ICustomerService customerService, ITransactionOnAccountService transactionOnAccountService)
        {
            _accountService = accountService;
            _customerService = customerService;
            _transactionOnAccountService = transactionOnAccountService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllAccount()
        {
            var accounts = _accountService.GetAll();
            return Ok(accounts);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAccountById(int id)
        {
           var accounts= _accountService.GetAccountsById(id);
           return Ok(accounts);
        }

        [HttpPost]
        [Route("freeze")]
        public  IActionResult FreezeAccount([FromBody] AccountIdDto accountDto)
        {
           var account = _accountService.GetAccountByNumber(accountDto.AccountNumber);
            if(account.Balance != 0)
            {
                return BadRequest("Hesap kapatabilmek için bakiyeniz 0 olmalıdır.");
            }
           account.isActive = false;
            _accountService.Update(account);
            return Ok(account);
        }

        [HttpPost]
        [Route("add")]
        public async Task <IActionResult> AddAccount([FromBody] CustomerIdDto customer)
        {

            Account account=new Account()
            {
            
                AccountNo = 1001+ _accountService.GetAccountCount(customer.CustomerId),
                AccountNumber= _accountService.GetAccountNumber(),
                Balance = 0,
                CustomerId = customer.CustomerId,
                RegistrationTime =DateTime.Now,
                isActive = true
            };
              _accountService.Add(account);
             return Ok(account);
        }

        [HttpGet]
        [Route("customer")]
        public IActionResult GetCustomer()
        {
            var customer = _customerService.GetAll();
            return Ok(customer);
        }
        [HttpPost]
        [Route("havale")]
        public IActionResult  MoneyTransferWithHavale([FromBody]HavaleDto havaleDto)
        {
            if (_accountService.GetAccountByNumber(havaleDto.ReceivingAccountId)==null)
            {
                return BadRequest();
            }
            else
            {
                var sendingAccount = _accountService.GetAccountByNumber(havaleDto.SendingAccountId);
                var receivingAccount = _accountService.GetAccountByNumber(havaleDto.ReceivingAccountId);
                if (havaleDto.Money!=0 && havaleDto.Money <= sendingAccount.Balance && receivingAccount.isActive==true)
                {
                    sendingAccount.Balance -= havaleDto.Money;
                    receivingAccount.Balance += havaleDto.Money;
                    _accountService.Update(sendingAccount);
                    _accountService.Update(receivingAccount);
                    var transaction = new TransactionOnAccount();
                    transaction.ReceivingAccountId = havaleDto.ReceivingAccountId;
                    transaction.SendingAccountId = havaleDto.SendingAccountId;
                    transaction.TransactionTime = DateTime.Now;
                    transaction.AmountOfMoney = havaleDto.Money;
                    transaction.ProcessType = "mobil";
                    transaction.AccountId = sendingAccount.AccountId;
                    _transactionOnAccountService.Add(transaction);
                  
                    return Ok();
                }
                return BadRequest();   
            }
        }
        [HttpPost]
        [Route("virman")]
        public IActionResult MoneyTransferWithVirman([FromBody]VirmanDto virmanDto)
        {    
            if (_accountService.GetAccountByNumber(virmanDto.ReceivingAccountId) == null)
            {
                return BadRequest();
            }
            else
            {
                var sendingAccount = _accountService.GetAccountByNumber(virmanDto.SendingAccountId);
                var receivingAccount = _accountService.GetAccountByNumber(virmanDto.ReceivingAccountId);
                if (virmanDto.Money!=0 && virmanDto.Money <= sendingAccount.Balance)
                {
                    sendingAccount.Balance -= virmanDto.Money;
                    receivingAccount.Balance += virmanDto.Money;
                    _accountService.Update(sendingAccount);
                    _accountService.Update(receivingAccount);
                    var transaction = new TransactionOnAccount();
                    transaction.ReceivingAccountId =
                        receivingAccount.AccountNumber + "/" + receivingAccount.AccountNo.ToString();
                    transaction.SendingAccountId = sendingAccount.AccountNumber + "/" + sendingAccount.AccountNo.ToString();
                    transaction.TransactionTime = DateTime.Now;
                    transaction.AmountOfMoney = virmanDto.Money;
                    transaction.ProcessType = "mobil";
                    transaction.AccountId = sendingAccount.AccountId;
                    _transactionOnAccountService.Add(transaction);

                    return Ok();
                }
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("PayMoney")]
        public IActionResult AddMoneyToAccount([FromBody] MoneyTransferDto moneyTransferDto)
        {
            if(moneyTransferDto.Money!=0){
  var account = _accountService.GetAccountByNumber(moneyTransferDto.AccountNumber);
            account.Balance += moneyTransferDto.Money;
            _accountService.Update(account);
            return Ok();
            }
            return BadRequest();
          
        }

        [HttpPost]
        [Route("WithdrawMoney")]
        public IActionResult WithdrawMoneyToAccount([FromBody] MoneyTransferDto moneyTransferDto)
        {
                      

            var account = _accountService.GetAccountByNumber(moneyTransferDto.AccountNumber);
            if (moneyTransferDto.Money<=account.Balance && moneyTransferDto.Money!=0)
            {
                account.Balance -= moneyTransferDto.Money;
                _accountService.Update(account);
                return Ok();
            }
            return BadRequest();
        }
          [HttpPost]
        [Route("paydebt/{subscriberNo}")]
        public IActionResult PayBill(string subscriberNo, [FromBody]AccountIdDto accountIdDto)
        {
            var account = _accountService.GetAccountByNumber(accountIdDto.AccountNumber);
            var url = String.Format("http://localhost:63397/api/payments/{0}", subscriberNo);
            WebRequest request = HttpWebRequest.Create(url);

            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string Joke_JSON = reader.ReadToEnd();


            PhoneBill phoneBill = Newtonsoft.Json.JsonConvert.DeserializeObject<PhoneBill>(Joke_JSON);
            if (account.Balance >= phoneBill.Price)
            {
                account.Balance -= phoneBill.Price;
                _accountService.Update(account);

                var url2 = String.Format("http://localhost:63397/api/payments/okey/{0}", subscriberNo);

                WebRequest request2 = HttpWebRequest.Create(url2);
                WebResponse response2 = request2.GetResponse();
                StreamReader reader2 = new StreamReader(response2.GetResponseStream());


            }
            else
                return BadRequest();
            return Ok(phoneBill);


        }
        [HttpGet]
        [Route("querydebt/{subscriberNo}")]
        public IActionResult GetDebt(string subscriberNo)
        {
            var url = String.Format("http://localhost:63397/api/payments/{0}",subscriberNo);
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string Joke_JSON = reader.ReadToEnd();


            PhoneBill phoneBill = Newtonsoft.Json.JsonConvert.DeserializeObject<PhoneBill>(Joke_JSON);
            return Ok(phoneBill);


        }
         public class PhoneBill
        {

            public int Id { get; set; }

            public string SubscriberNo { get; set; }

            public decimal Price { get; set; }

        }
    }
}