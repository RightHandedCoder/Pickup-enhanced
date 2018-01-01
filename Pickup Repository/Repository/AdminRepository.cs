using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        DataContext context = new DataContext();

        public int GetLastAdminId(Admin admin)
        {
            return context.Set<Admin>().Where(a => a.Email == admin.Email).SingleOrDefault().Id;
        }
    }
}
