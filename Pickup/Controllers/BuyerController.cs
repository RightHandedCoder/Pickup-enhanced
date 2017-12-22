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
        UserRepository<Buyer> buyerRepo = new UserRepository<Buyer>();

        // GET: Buyer
        public ActionResult Index(int id)
        {
            return View(buyerRepo.Get(id));
        }

        public ActionResult Logout()
        {
            Session["USER"] = null;
            Session["USERID"] = null;
            return RedirectToAction("Index","Home");
        }
    }
}