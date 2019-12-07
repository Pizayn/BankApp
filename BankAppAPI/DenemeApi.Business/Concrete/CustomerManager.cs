using System;
using System.Collections.Generic;
using System.Text;
using DenemeApi.Business.Abstract;
using DenemeApi.DataAccess.Abstract;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.Business.Concrete
{
  public  class CustomerManager:ICustomerService
  {
      private ICustomerDal _customerDal;

      public CustomerManager(ICustomerDal customerDal)
      {
          _customerDal = customerDal;
      }

      public List<Customer> GetAll()
      {
          return _customerDal.GetList();
      }

      public void Add(Customer customer)
      {
          _customerDal.Add(customer);
      }
    }
}
