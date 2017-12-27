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
        CartRepository cartRepo = new CartRepository();
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

        public ActionResult AddToCart(int id)
        {
            if (Session["CART"] != null)
            {
                List<int> list = Session["CART"] as List<int>;
                list.Add(id);
                Session["CART"] = list;

                return RedirectToAction("Index", "Home");
            }

            else return View("Error");
        }

        public ActionResult CheckOut()
        {
            if (Session["USERID"] != null)
            {
                if (Session["USER"].ToString() == "Buyer")
                {
                    return View(cartRepo.GetCurrentCartProducts(Session["CART"] as List<int>));
                }

                else return View("Error");
            }

            else return RedirectToAction("Index","Login", new { @id = 1});
        }

        [ActionName("Payment")]
        public ActionResult ConfirmOrder()
        {
            ShoppingCart cart = new ShoppingCart()
            {
                BuyerId = (int)Session["USERID"],
                Time = DateTime.Now.ToShortTimeString(),
                Date = DateTime.Now.ToShortDateString()
            };

            if (cartRepo.Insert(cart) == 1)
            {
                int cart_id = cartRepo.GetLastCartId((int)Session["USERID"]);

                if (cartRepo.InsertSoldProducts((List<int>)Session["CART"], cart_id) == 1)
                {
                    Session["CART"] = new List<int>();

                    return RedirectToAction("Index", "Home");
                }

                else return View("Error");
                
            }

            else return View("Error");
        }

        //public string Get(int id)
        //{
        //    return cartRepo.GetLastCart(id).ToString();
        //}
    }
}