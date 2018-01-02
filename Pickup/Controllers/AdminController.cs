﻿using Pickup.App_Start;
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
       

        public AdminController()
        {
            adminService = Injector.Container.Resolve<IAdminService>();
            catagoryService = Injector.Container.Resolve<ICatagoryService>();
            areaService = Injector.Container.Resolve<IAreaService>();
        }

        public ActionResult Index(int id)
        {
            Admin admin = adminService.Get(id);

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


    }

}