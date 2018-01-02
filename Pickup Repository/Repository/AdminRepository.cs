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

        public override int Update(Admin entity)
        {
            Admin a = context.Admins.SingleOrDefault(p => p.Id == entity.Id);

            a.FirstName = entity.FirstName;
            a.LastName = entity.LastName;
            a.Gender = entity.Gender;
            a.Email = entity.Email;
            a.Phone = entity.Phone;
            a.AreaId = entity.AreaId;
            a.AreaName = entity.AreaName;
            a.DepartmentId = entity.DepartmentId;
            a.DepartmentName = entity.DepartmentName;

            return context.SaveChanges();
        }
    }
}
