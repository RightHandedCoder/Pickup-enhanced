using Oracle_Repository;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index(int id)
        {
            if (id == 1)
            {
                return RedirectToAction("Buyer");
            }

            else if (id == 2)
            {
                return RedirectToAction("Seller");
            }

            else return View("Error");
        }

        public ActionResult Buyer()
        {
            return View();
        }

        public ActionResult Seller()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buyer(Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                UserRepository<Buyer> buyerRepo = new UserRepository<Buyer>();

                if (buyerRepo.Insert(buyer) == 1)
                {
                    return RedirectToAction("Index", "Home");
                }

                else return View("Error");
            }

            else return View(buyer);
        }

        [HttpPost]
        public ActionResult Seller(Seller seller)
        {
            if (ModelState.IsValid)
            {
                UserRepository<Seller> sellerRepo = new UserRepository<Seller>();

                if (sellerRepo.Insert(seller) == 1)
                {
                    return RedirectToAction("Index", "Home");
                }

                else return View("Error");
            }

            else return View(seller);
        }
    }
}