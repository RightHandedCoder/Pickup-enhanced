using Oracle_Repository;
using Pickup.App_Start;
using Pickup_Entity;
using Pickup_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.ClientServices;

namespace Pickup.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository productRepo = new ProductRepository();

        public ActionResult Index()
        {
            //gets data from API
            //return View();
  
            return View("Index_Oracle", productRepo.GetAll());
        }

        public ActionResult Details(int id)
        {
            //gets data from API
            //return View();

            return View("Details_Oracle",productRepo.Get(id));
        }

        public ActionResult Login(int id)
        {
            //return View();

            return RedirectToAction("Index", "Login", new { @id = id});
        }

        public ActionResult Register(int id)
        {
            return RedirectToAction("Index", "Registration", new { @id = id });
        }
    }
}