using System;
using System.Collections.Generic;
using System.Text;
using DenemeApi.Business.Abstract;
using DenemeApi.DataAccess.Abstract;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.Business.Concrete
{
    public class SupplementManager:ISupplementService
    {
        private ISupplementDal _supplementDal;

        public SupplementManager(ISupplementDal supplementDal)
        {
            _supplementDal = supplementDal;
        }

        public List<Supplement> GetAll()
        {
            return _supplementDal.GetList();
        }

        public Supplement GetSuppplementById(int id)
        {
            return _supplementDal.Get(x => x.ID == id);
        }
    }
}
