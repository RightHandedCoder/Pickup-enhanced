using Pickup_Entity;
using Pickup_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public class SellerService : Service<Seller>, ISellerService
    {
        SellerRepository repo = new SellerRepository();

        public int GetLastSellerId(Seller seller)
        {
            return repo.GetLastSellerId(seller);
        }
    }
}
