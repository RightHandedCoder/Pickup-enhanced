using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        DataContext context = new DataContext();

        public override int Update(ShoppingCart entity)
        {
            ShoppingCart s = context.ShoppingCarts.FirstOrDefault(a => a.Id == entity.Id);

            s.BuyerId = entity.BuyerId;
            s.Date = entity.Date;
            s.Time = entity.Time;

            return context.SaveChanges();
        }
    }
}
