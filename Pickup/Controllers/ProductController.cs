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
    public class ProductController : Controller
    {
        IProductService productService;
        ICatagoryService catagoryService;

        public ProductController()
        {
            catagoryService = Injector.Container.Resolve<ICatagoryService>();
            productService = Injector.Container.Resolve<IProductService>();
        }

        public ActionResult Add()
        {
            List<SelectListItem> catagoryList = new List<SelectListItem>();

            foreach (Catagory catagory in catagoryService.GetAll())
            {
                catagoryList.Add(new SelectListItem() { Text = catagory.CatagoryName, Value = catagory.Id.ToString() });
            }

            ViewBag.CatagoryList = catagoryList;

            return View("AddProduct");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = productService.Get(id);
            AddProductViewModel productToEdit = new AddProductViewModel() { Id=product.Id, CatagoryId=product.CatagoryId.ToString(), ProductName=product.ProductName, Price=product.Price};
            return View(productToEdit);
        }
    }
}