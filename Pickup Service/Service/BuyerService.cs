using Pickup_Entity;
using Pickup_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public class BuyerService : Service<Buyer>, IBuyerService
    {
        BuyerRepository repo = new BuyerRepository();

        public int GetLastBuyerId(Buyer buyer)
        {
            return repo.GetLastBuyerId(buyer);
        }
    }
}
