using Pickup.App_Start;
using Pickup_Entity;
using Pickup_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class ShoppingCartController : Controller
    {
        IShoppingCartService cartService;
        IProductService productService;
        ICatagoryService catagoryService;
        IBuyerPurchaseService purchaseService;

        public ShoppingCartController()
        {
            cartService = Injector.Container.Resolve<IShoppingCartService>();
            productService = Injector.Container.Resolve<IProductService>();
            catagoryService = Injector.Container.Resolve<ICatagoryService>();
            purchaseService = Injector.Container.Resolve<IBuyerPurchaseService>();
        }

        public ActionResult Index()
        {
            List<Product> productList = new List<Product>();
            List<int> itemList = Session["CART"] as List<int>;

            foreach (int item in itemList)
            {
                Product p = productService.Get(item);
                p.CatagoryName = catagoryService.Get(p.CatagoryId).CatagoryName;

                productList.Add(p);

            }

            return View(productList);
        }

        public ActionResult AddToCart(int id)
        {
            List<int> list = Session["CART"] as List<int>;
            list.Add(id);
            Session["CART"] = list;

            return RedirectToAction("Index","Home");

        }

        public ActionResult Delete(int id)
        {
            List<int> list = Session["CART"] as List<int>;
            list.Remove(id);
            Session["CART"] = list;

            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult Checkout(int total)
        {
            return RedirectToAction("Invoice","Buyer", new { @Total=total});
        }

        public ActionResult Confirm(int id)
        {
            ShoppingCart cart = new ShoppingCart() { BuyerId = id, Date = DateTime.Now.ToShortDateString(), Time = DateTime.Now.ToShortTimeString() };

            List<int> list = Session["CART"] as List<int>;

            foreach (int item in list)
            {
                BuyerPurchase purchase = new BuyerPurchase() { BuyerId = (int)Session["USERID"], ProductId = item, Date = DateTime.Now.ToShortDateString() };
                purchaseService.Insert(purchase);
            }

            if (cartService.Insert(cart) == 1)
            {
                return View();
            }

            else return View("Error");
        }
    }
}
