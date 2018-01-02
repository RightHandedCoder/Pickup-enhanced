using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        DataContext context = new DataContext();

        public override List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            foreach (Product product in context.Products.ToList())
            {
                Catagory catagory = context.Catagories.Find(product.CatagoryId);
                Seller seller = context.Sellers.Find(product.SellerId);

                product.CatagoryName = catagory.CatagoryName;
                product.SellerName = seller.FirstName + " " + seller.LastName;

                list.Add(product);
            }

            return list;
        }

        public override int Update(Product entity)
        {
            Product pro = context.Set<Product>().Find(entity.Id);

            pro.ProductName = entity.ProductName;
            pro.Price = entity.Price;

            return context.SaveChanges();
        }
    }
}
