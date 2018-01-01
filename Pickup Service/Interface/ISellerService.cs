using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public interface ISellerService : IService<Seller>
    {
        int GetLastSellerId(Seller seller);
    }
}
