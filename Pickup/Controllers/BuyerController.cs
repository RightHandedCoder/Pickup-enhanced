using Oracle_Repository;
using Pickup.Models;
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
        CredentialRepository<BuyerCredential> credentialRepo = new CredentialRepository<BuyerCredential>();

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

        public ActionResult MyPurchase(int id)
        {
            return View(buyerRepo.GetRecentPurchase(id));
        }

        public ActionResult Details(int id)
        {
            return View(buyerRepo.Get(id));
        }

        public ActionResult ChangePassword()
        { 
            return View();
        }

        public ActionResult Edit(int id)
        {
            Repository<Area> areaRepo = new Repository<Area>();
            List<SelectListItem> areaList = new List<SelectListItem>();

            foreach (var item in areaRepo.GetAll())
            {
                areaList.Add(new SelectListItem() {

                    Text=item.AreaName,
                    Value=item.Id.ToString()
                });
            }

            ViewBag.Area = areaList;

            return View(buyerRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                if (buyerRepo.Update(buyer) == 1)
                {
                    return RedirectToAction("Details", "Buyer", new { id = buyer.Id});
                }

                else return View("Error");
            }

            else return View(buyer);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel credential)
        {
            BuyerCredential oldCredential = credentialRepo.GetById((int)Session["USERID"]) as BuyerCredential;

            if (credential.OldPassword == oldCredential.Password)
            {
                if (credential.NewPassword == credential.ConfirmPassword)
                {
                    BuyerCredential newCredential = new BuyerCredential() { Id = oldCredential.Id, Password = credential.NewPassword };

                    if (credentialRepo.UpdatePassword(newCredential) == 1)
                    {
                        return RedirectToAction("Index", "Buyer", new { id = (int)Session["USERID"] });
                    }

                    else return View(credential);
                }

                else return View(credential);
            }

            else return View(credential);
        }
    }
}