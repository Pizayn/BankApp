using System;
using System.Collections.Generic;
using System.Text;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.Business.Abstract
{
   public interface ICustomerService
   {
       List<Customer> GetAll();
       void Add(Customer customer);
   }
}
