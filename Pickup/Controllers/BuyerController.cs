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
    public class BuyerController : Controller
    {
        IBuyerService buyerService;
        IAreaService areaService;
        IBuyerPurchaseService purchaseService;
        IProductService productService;
        ICatagoryService catagoryService;

        public BuyerController()
        {
            buyerService = Injector.Container.Resolve<IBuyerService>();
            areaService = Injector.Container.Resolve<IAreaService>();
            purchaseService = Injector.Container.Resolve<IBuyerPurchaseService>();
            productService = Injector.Container.Resolve<IProductService>();
            catagoryService = Injector.Container.Resolve<ICatagoryService>();
        }

        public ActionResult Index(int id)
        {
            Buyer buyer = buyerService.Get(id);

            return View(buyer);
        }

        public ActionResult Details(int id)
        {
            Buyer buyer = buyerService.Get(id);
            buyer.AreaName = areaService.Get(buyer.AreaId).AreaName;

            return View(buyer);
        }

        public ActionResult Edit(int id)
        {
            Buyer buyer = buyerService.Get(id);
            buyer.AreaName = areaService.Get(buyer.AreaId).AreaName;

            return View(buyer);
        }

        [HttpPost]
        public ActionResult Edit(Buyer buyer)
        {
            buyer.Id = (int)Session["USERID"];

            if (buyerService.Update(buyer) == 1)
            {
                return RedirectToAction("Details", "Buyer", new { @id = Session["USERID"] });
            }

            else return View("Error");
        }

        public ActionResult MyPurchase(int id)
        {
            List<Product> list = new List<Product>();

            foreach (BuyerPurchase item in purchaseService.GetAll())
            {
                if (item.BuyerId==id)
                {
                    Product p = productService.Get(item.ProductId);
                    p.Date = item.Date;
                    p.CatagoryName = catagoryService.Get(p.CatagoryId).CatagoryName;

                    list.Add(p);
                }
            }

            return View(list);
        }

        public ActionResult Logout()
        {
            Session["USERID"] = "";
            Session["USER"] = "";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Invoice(int Total)
        {
            ViewBag.Total = Total;

            Buyer b = buyerService.Get((int)Session["USERID"]);
            return View(b);
        }

    }
}