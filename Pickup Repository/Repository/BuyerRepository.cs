using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class BuyerRepository : Repository<Buyer>, IBuyerRepository
    {
        DataContext context = new DataContext();

        public int GetLastBuyerId(Buyer buyer)
        {
            return context.Set<Buyer>().Where(b => b.Email == buyer.Email).SingleOrDefault().Id;
        }
    }
}
