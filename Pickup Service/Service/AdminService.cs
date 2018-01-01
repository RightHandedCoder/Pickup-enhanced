using Pickup_Entity;
using Pickup_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Service
{
    public class AdminService : Service<Admin>, IAdminService
    {
        AdminRepository repo = new AdminRepository();

        public int GetLastAdminId(Admin admin)
        {
            return repo.GetLastAdminId(admin);
        }
    }
}
