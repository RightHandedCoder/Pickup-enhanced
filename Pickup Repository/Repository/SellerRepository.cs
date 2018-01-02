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

        public override int Update(Seller entity)
        {
            Seller s = context.Sellers.FirstOrDefault(a => a.Id == entity.Id);

            s.FirstName = entity.FirstName;
            s.LastName = entity.LastName;
            s.Gender = entity.Gender;
            s.Email = entity.Email;
            s.Phone = entity.Phone;
            s.AreaId = entity.AreaId;
            s.AreaName = entity.AreaName;
            s.ShopName = entity.ShopName;

            return context.SaveChanges();
        }
    }
}
