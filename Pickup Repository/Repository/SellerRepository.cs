using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class SellerRepository : Repository<Seller>, ISellerRepository
    {
        DataContext context = new DataContext();

        public int GetLastSellerId(Seller seller)
        {
            return context.Set<Seller>().Where(s => s.Email == seller.Email).SingleOrDefault().Id;
        }
    }
}
