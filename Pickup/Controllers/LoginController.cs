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
    public class LoginController : Controller
    {
        ICredentialService<BuyerCredential> buyerService;
        ICredentialService<SellerCredential> sellerService;
        ICredentialService<AdminCredential> adminService;

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Login: Buyer
            else if (id == 1)
            {
                return RedirectToAction("BuyerLogin", "Login");
            }

            // Login: Seller5
            else if (id == 2)
            {
                return RedirectToAction("SellerLogin", "Login");
            }

            // Login: Admin
            else if (id==3)
            {
                return RedirectToAction("AdminLogin", "Login");
            }

            else return View("Error");
        }

        [HttpGet]
        public ActionResult BuyerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuyerLogin(BuyerCredential credential)
        {
            buyerService = Injector.Container.Resolve<ICredentialService<BuyerCredential>>();

            BuyerCredential credentialFromDb = buyerService.ValidateCredential(credential) as BuyerCredential;

            try
            {
                if (credentialFromDb.Status)
                {
                    Session["USERID"] = credentialFromDb.BuyerId;
                    Session["USER"] = "buyer";
                    return RedirectToAction("Index", "Buyer", new { id = credentialFromDb.BuyerId });
                }

                else return View("Blocked");
            }

            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult SellerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SellerLogin(SellerCredential credential)
        {
            sellerService = Injector.Container.Resolve<ICredentialService<SellerCredential>>();

            if (ModelState.IsValid)
            {
                SellerCredential credentialFromDb = sellerService.ValidateCredential(credential) as SellerCredential;

                try
                { 
                    if (credentialFromDb.Status)
                    {
                        return RedirectToAction("Index", "Seller", new { id = credentialFromDb.SellerId });
                    }

                    else return View("Blocked");
                }

                catch (Exception)
                {
                    return View("Error");
                }
            }

            else return View(credential);
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminCredential credential)
        {
            adminService = Injector.Container.Resolve<ICredentialService<AdminCredential>>();

            if (ModelState.IsValid)
            {
                AdminCredential credentialFromDb = adminService.ValidateCredential(credential) as AdminCredential;

                try
                {
                    if (credentialFromDb.Status)
                    {
                        Session["USERID"] = credentialFromDb.AdminId;
                        Session["USER"] = "admin";
                        return RedirectToAction("Index", "Admin", new { id = credentialFromDb.AdminId });
                    }

                    else return View("Blocked");
                }

                catch (Exception)
                {
                    return View("Error");
                }
            }

            else return View(credential);
        }
    }
}