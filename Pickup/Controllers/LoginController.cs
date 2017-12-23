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

            else if (id == 3)
            {
                return RedirectToAction("Admin");
            }

            else return RedirectToAction("Index", "Home");
        }

        public ActionResult Buyer()
        {
            return View("Buyer_Login_Oracle");
        }

        public ActionResult Seller()
        {
            return View("Seller_Login_Oracle");
        }

        public ActionResult Admin()
        {
            return View("Admin_Login_Oracle");
        }

        [HttpPost]
        public ActionResult Buyer(BuyerCredential credential)
        {
            if (ModelState.IsValid)
            {
                CredentialRepository<BuyerCredential> credentialRepo = new CredentialRepository<BuyerCredential>();
                int id = credentialRepo.Get(credential);
                Session["USER"] = "Buyer";
                Session["USERID"] = id;
                Session["CART"] = new List<int>();

                return RedirectToAction("Index", "Buyer", new { @id = id });
            }

            else return View(credential);
           
        }

        [HttpPost]
        public ActionResult Seller(SellerCredential credential)
        {
            if (ModelState.IsValid)
            {
                CredentialRepository<SellerCredential> credentialRepo = new CredentialRepository<SellerCredential>();
                int id = credentialRepo.Get(credential);
                Session["USER"] = "Seller";
                Session["USERID"] = id;

                return RedirectToAction("Index", "Seller", new { @id = id });
            }

            else return View(credential);  
        }

        [HttpPost]
        public ActionResult Admin(AdminCredential credential)
        {
            if (ModelState.IsValid)
            {
                CredentialRepository<AdminCredential> credentialRepo = new CredentialRepository<AdminCredential>();
                int id = credentialRepo.Get(credential);
                Session["USER"] = "Admin";
                Session["USERID"] = id;

                return RedirectToAction("Index", "Admin", new { @id = id });
            }

            else return View(credential);
            
        }

    }
}