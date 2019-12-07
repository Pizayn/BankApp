using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DenemeApi.DataAccess.Abstract;
using DenemeApi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DenemeApi.DataAccess.Concrete
{
  public  class Repository<TEntity,TContext>:IRepository<TEntity> where  TContext:DbContext,new()
  where TEntity : class,new()
    {
       

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filterExpression = null)
        {
            using (TContext context = new TContext())
            {
                return filterExpression == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filterExpression).ToList();
            }
          
        }
        public  TEntity Get(Expression<Func<TEntity, bool>> filterExpression = null)
        {
            using (TContext context=new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filterExpression);
             
            }
        }

       public  void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                 context.SaveChanges();
            }
        }

       public  async void Update(TEntity entity)
       {
           using (TContext context = new TContext())
           {
               var updatedEntity = context.Entry(entity);
               updatedEntity.State = EntityState.Modified;
             await  context.SaveChangesAsync();
           }
        }
    }
}
