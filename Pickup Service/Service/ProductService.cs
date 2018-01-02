using Pickup_Entity;
using Pickup_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public class ProductService : Service<Product>, IProductService
    {
        ProductRepository repo = new ProductRepository();

        public override List<Product> GetAll()
        {
            return repo.GetAll();
        }

        public override int Update(Product entity)
        {
            return repo.Update(entity);
        }
    }
}
