using Oracle_Repository;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
            return View("Buyer_Login_Oracle");
        }

        public ActionResult Seller()
        {
            return View("Seller_Login_Oracle");
        }

        [HttpPost]
        public ActionResult Buyer(BuyerCredential credential)
        {
            CredentialRepository<BuyerCredential> credentialRepo = new CredentialRepository<BuyerCredential>();

            return RedirectToAction("Index", "Buyer", new { @id = credentialRepo.Get(credential) });
        }

        [HttpPost]
        public ActionResult Seller(SellerCredential credential)
        {
            CredentialRepository<SellerCredential> credentialRepo = new CredentialRepository<SellerCredential>();

            return RedirectToAction("Index", "Seller", new { @id = credentialRepo.Get(credential) });
        }

    }
}