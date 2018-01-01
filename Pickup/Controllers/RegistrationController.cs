using Pickup.App_Start;
using Pickup.Models;
using Pickup_Entity;
using Pickup_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class RegistrationController : Controller
    {
        IBuyerService buyerService;
        //ISellerService sellerService;
        ICredentialService<BuyerCredential> buyerCredentialService;
        //ICredentialService<SellerCredential> sellerCredentialService;
        IAreaService areaService;
        
        public RegistrationController()
        {
            areaService = Injector.Container.Resolve<IAreaService>();
            buyerService = Injector.Container.Resolve<IBuyerService>();
            buyerCredentialService = Injector.Container.Resolve<ICredentialService<BuyerCredential>>();
        }

        public ActionResult Index(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index", "Home");
            }

            else if (id==1)
            {
                return RedirectToAction("BuyerRegistration","Registration");
            }

            else if (id==2)
            {
                return RedirectToAction("SellerRegistration", "Registration");
            }

            else return View("Error");
        }

        [HttpGet]
        public ActionResult BuyerRegistration()
        {
            List<SelectListItem> areaList = new List<SelectListItem>();

            foreach (Area area in areaService.GetAll())
            {
                areaList.Add(new SelectListItem() { Text=area.AreaName, Value=area.Id.ToString()});
            }

            ViewBag.AreaList = areaList;

            return View();
        }

        [HttpPost]
        public ActionResult BuyerRegistration(BuyerRegistrationViewModel buyerModel)
        {
            if (ModelState.IsValid)
            {
                Buyer buyer = new Buyer() { FirstName = buyerModel.FirstName, LastName = buyerModel.LastName, Gender = buyerModel.Gender, Email = buyerModel.Email, Phone = buyerModel.Phone, Address = buyerModel.Address, AreaId = Convert.ToInt32(buyerModel.AreaId)};

                if (buyerService.Insert(buyer) == 1)
                {
                    buyer.Id = buyerService.GetLastBuyerId(buyer);
                    BuyerCredential credential = new BuyerCredential() { Username = buyerModel.Username, Password = buyerModel.Password, BuyerId = buyer.Id, Status = true};

                    if (buyerCredentialService.Insert(credential) == 1)
                    {
                        return RedirectToAction("Index", "Login", new { id = 1 });
                    }

                    else return View("Error");
                }

                else return View("Error");
                
            }

            else return View(buyerModel);
        }
    }
}