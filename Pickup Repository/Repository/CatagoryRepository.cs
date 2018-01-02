using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class CatagoryRepository : Repository<Catagory>, ICatagoryRepository
    {
        DataContext context = new DataContext();
        public override int Update(Catagory entity)
        {
            Catagory c = context.Catagories.FirstOrDefault(a => a.Id == entity.Id);

            c.CatagoryName = entity.CatagoryName;
            return context.SaveChanges();
        }
    }
}
