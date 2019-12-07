using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DenemeApi.Entities.Concrete;

namespace DenemeApi.DataAccess.Abstract
{
   public interface IRepository<T> where T:class,new()
   {
       List<T> GetList(Expression<Func<T,bool>>filterExpression=null);
       T Get(Expression<Func<T, bool>> filterExpression = null);
       void Add(T entity);
        void  Update(T entity);

    }
}
