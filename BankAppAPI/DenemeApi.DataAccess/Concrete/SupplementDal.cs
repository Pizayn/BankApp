using System;
using System.Collections.Generic;
using System.Text;
using DenemeApi.DataAccess.Abstract;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.DataAccess.Concrete
{
    public class SupplementDal:Repository<Supplement,DenemeContext>,ISupplementDal
    {
    }
}
