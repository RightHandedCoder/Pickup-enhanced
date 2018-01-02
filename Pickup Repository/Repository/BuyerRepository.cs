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

        public override int Update(Buyer entity)
        {
            Buyer b = context.Buyers.SingleOrDefault(a => a.Id == entity.Id);

            b.FirstName = entity.FirstName;
            b.LastName = entity.LastName;
            b.Gender = entity.Gender;
            b.Email = entity.Email;
            b.Phone = entity.Phone;
            b.AreaId = entity.AreaId;
            b.AreaName = entity.AreaName;
            b.Address = entity.Address;

            return context.SaveChanges();
        }
    }
}
