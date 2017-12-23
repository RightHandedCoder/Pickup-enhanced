using Oracle_Repository;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class CartController : Controller
    {
        Repository<Product> productRepo = new Repository<Product>();

        // GET: Cart
        public ActionResult Index()
        {
            List<Product> productList = new List<Product>();
            List<int> list = Session["CART"] as List<int>;

            foreach (int id in list)
            {
                productList.Add(productRepo.Get(id));
            }

            return View(productList);
        }

        public ActionResult Delete(int id)
        {
            List<int> list = Session["Cart"] as List<int>;
            list.Remove(id);
            Session["CART"] = list;
            return RedirectToAction("Index");
        }



    }
}