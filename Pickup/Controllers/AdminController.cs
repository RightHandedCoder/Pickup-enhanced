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
    public class AdminController : Controller
    {
        IAdminService adminService;
        ICatagoryService catagoryService;
        IAreaService areaService;
        IProductService productService;
        IBuyerPurchaseService purchaseService;
        IBuyerService buyerService;
       

        public AdminController()
        {
            adminService = Injector.Container.Resolve<IAdminService>();
            catagoryService = Injector.Container.Resolve<ICatagoryService>();
            areaService = Injector.Container.Resolve<IAreaService>();
            productService = Injector.Container.Resolve<IProductService>();
            purchaseService = Injector.Container.Resolve<IBuyerPurchaseService>();
            buyerService = Injector.Container.Resolve<IBuyerService>();
        }

        public ActionResult Index(int id)
        {
            Admin admin = adminService.Get(id);

            return View(admin);
        }

        public ActionResult Details(int id)
        {
            Admin admin = adminService.Get(id);
            admin.AreaName = areaService.Get(admin.AreaId).AreaName;

            return View(admin);
        }

        public ActionResult AddProduct()
        {
            return RedirectToAction("Add","Product");
        }

        public ActionResult EditProduct(int id)
        {
            return RedirectToAction("Edit", "Product", new { @id = id });
        }

        public ActionResult DeleteProduct(int id)
        {
            return RedirectToAction("DeleteProduct", "Product", new { @id = id });
        }

        public ActionResult AddArea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddArea(Area a)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    areaService.Insert(a);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {

                    return View("Error");
                }
            }

            return View(a);
        }

        public ActionResult AddCatagory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCatagory(Catagory c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    catagoryService.Insert(c);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {

                    return View("Error");
                }

                
            }

            return View(c);
        }

        public ActionResult Purchase()
        {
            List<BuyerPurchase> list = new List<BuyerPurchase>();

            foreach (BuyerPurchase item in purchaseService.GetAll())
            {
                Buyer buyer = buyerService.Get(item.BuyerId);
                Product product = productService.Get(item.ProductId);

                item.BuyerName = buyer.FirstName + " " + buyer.LastName;
                item.ProductName = product.ProductName;

                list.Add(item);
            }

            return View(list);
        }

        public ActionResult Products()
        {
            return RedirectToAction("Index","Product");
        }

        public ActionResult Logout()
        {
            Session["USERID"] = "";
            Session["USER"] = "";
            return RedirectToAction("Index", "Home");
        }

        public ActionResult BuyerList()
        {
            List<Buyer> buyerList = new List<Buyer>();

            foreach (Buyer item in buyerService.GetAll())
            {
                item.AreaName = areaService.Get(item.AreaId).AreaName;
                buyerList.Add(item);
            }

            return View(buyerList);
        }


    }

}