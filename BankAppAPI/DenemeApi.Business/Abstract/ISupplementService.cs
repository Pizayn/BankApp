using System;
using System.Collections.Generic;
using System.Text;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.Business.Abstract
{
  public  interface ISupplementService
  {
      List<Supplement> GetAll();
      Supplement GetSuppplementById(int id);
  }
}
