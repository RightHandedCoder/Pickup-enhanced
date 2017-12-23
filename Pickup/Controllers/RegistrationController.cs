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
            List<SelectListItem> list = new List<SelectListItem>();

            Repository<Area> areaRepo = new Repository<Area>();

            foreach (Area area in areaRepo.GetAll())
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = area.Id.ToString(),
                    Text = area.AreaName
                };

                list.Add(item);
            }

            ViewBag.AreaList = list;

            return View();
        }

        public ActionResult Seller()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            Repository<Area> areaRepo = new Repository<Area>();

            foreach (Area area in areaRepo.GetAll())
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = area.Id.ToString(),
                    Text = area.AreaName
                };

                list.Add(item);
            }

            ViewBag.AreaList = list;

            return View();
        }

        [HttpPost]
        public ActionResult Buyer(BuyerViewModel obj)
        {
            if (ModelState.IsValid)
            {
                UserRepository<Buyer> buyerRepo = new UserRepository<Buyer>();
                CredentialRepository<BuyerCredential> credentialRepo = new CredentialRepository<BuyerCredential>();

                Buyer buyer = new Buyer()
                {
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Gender = obj.Gender,
                    Email = obj.Email,
                    Phone = obj.Phone,
                    AreaId = obj.AreaId,
                    Address = obj.Address
                };

                BuyerCredential credential = new BuyerCredential()
                {
                    Username = obj.Username,
                    Password = obj.Password
                };

                if (buyerRepo.Insert(buyer) == 1 )
                {
                    int id = buyerRepo.GetId(buyer.Email);
                    credential.BuyerId = id;

                    if (credentialRepo.Insert(credential)==1)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    else return View("Error");
                }

                else return View("Error");
            }

            else return View(obj);
        }

        [HttpPost]
        public ActionResult Seller(SellerViewModel obj)
        {
            if (ModelState.IsValid)
            {
                UserRepository<Seller> sellerRepo = new UserRepository<Seller>();
                CredentialRepository<SellerCredential> credentialRepo = new CredentialRepository<SellerCredential>();

                Seller seller = new Seller()
                {
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Gender = obj.Gender,
                    Email = obj.Email,
                    Phone = obj.Phone,
                    AreaId = obj.AreaId,
                    ShopName = obj.ShopName
                };

                SellerCredential credential = new SellerCredential()
                {
                    Username = obj.Username,
                    Password = obj.Password
                };

                if (sellerRepo.Insert(seller) == 1)
                {
                    int id = sellerRepo.GetId(seller.Email);
                    credential.SellerId = id;

                    if (credentialRepo.Insert(credential) == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    else return View("Error");
                }

                else return View("Error");
            }

            else return View(obj);
        }
    }
}