namespace Pickup_Repository
{
    using Pickup_Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {
        //private static DataContext context;

        private DataContext()
        {

        }

        public static DataContext GetInstance()
        {
            //if (context == null)
            //{
            //    context = new DataContext();
            //    return context;
            //}

            //else return null;

            return new DataContext();
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<BuyerCredential> BuyerCredentials { get; set; }
        public DbSet<SellerCredential> SellerCredentials { get; set; }
        public DbSet<AdminCredential> AdminCredentials { get; set; }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Catagory> Catagories { get; set; }

    }

  
}