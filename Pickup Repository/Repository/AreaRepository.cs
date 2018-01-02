using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class AreaRepository : Repository<Area>, IAreaRepository
    {
        DataContext context = new DataContext();
        public override int Update(Area entity)
        {
            Area a = context.Areas.SingleOrDefault(p => p.Id == entity.Id);

            a.AreaName = entity.AreaName;
            return context.SaveChanges();
        }
    }
}
