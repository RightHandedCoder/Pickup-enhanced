using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        DataContext context = new DataContext();

        public virtual List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual int Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public virtual int Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public virtual int Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChanges();
        }
    }
}
