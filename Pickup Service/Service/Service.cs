using Pickup_Entity;
using Pickup_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        IRepository<TEntity> repo = new Repository<TEntity>();

        public virtual List<TEntity> GetAll()
        {
            return repo.GetAll();
        }

        public virtual TEntity Get(int id)
        {
            return repo.Get(id);
        }

        public virtual int Insert(TEntity entity)
        {
            return repo.Insert(entity);
        }

        public virtual int Update(TEntity entity)
        {
            return repo.Update(entity);
        }

        public virtual int Delete(TEntity entity)
        {
            return repo.Delete(entity);
        }
    }
}
