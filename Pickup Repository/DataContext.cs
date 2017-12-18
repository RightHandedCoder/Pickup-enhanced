namespace Pickup_Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        private static DataContext context;

        private DataContext()
        {

        }

        public DataContext GetInstance()
        {
            if (context == null)
            {
                context = new DataContext();
                return context;
            }

            else return null;
        }


      
    }

  
}