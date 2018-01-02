using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        DataContext context = new DataContext();

        public override int Update(Department entity)
        {
            Department d = context.Departments.FirstOrDefault(a => a.Id == entity.Id);

            d.DepartmentName = entity.DepartmentName;
            d.DepartmentLocation = entity.DepartmentLocation;

            return context.SaveChanges();
        }
    }
}
