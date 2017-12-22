using Oracle_Repository;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class SellerController : Controller
    {
        UserRepository<Seller> sellerRepo = new UserRepository<Seller>();

        // GET: Seller
        public ActionResult Index(int id)
        {
            return View(sellerRepo.Get(id));
        }

        public ActionResult Logout()
        {
            Session["USER"] = null;
            Session["USERID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}