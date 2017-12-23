using Oracle_Repository;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class BuyerController : Controller
    {
        BuyerRepository buyerRepo = new BuyerRepository();

        // GET: Buyer
        public ActionResult Index(int id)
        {
            return View(buyerRepo.Get(id));
        }

        public ActionResult AddToCart(int id)
        {
            //int cartId = buyerRepo.GetCartId((int)Session["USERID"]);

            //if (cartId!=0)
            //{
            //    if (buyerRepo.AddToCart(cartId, id) == 1)
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }

            //    else return View("Error");
            //}

            //else
            //{
            //    return View("Error");
            //}

            if (Session["CART"] != null)
            {
                List<int> list = Session["CART"] as List<int>;
                list.Add(id);
                Session["CART"] = list;

                return RedirectToAction("Index", "Home");
            }

            else return View("Error");
        }

        public ActionResult Logout()
        {
            Session["USER"] = null;
            Session["USERID"] = null;
            return RedirectToAction("Index","Home");
        }
    }
}