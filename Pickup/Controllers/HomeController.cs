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

        public ActionResult Index()
        {
            //gets data from API
            return View();
        }

        public ActionResult Details(int id)
        {
            //gets data from API
            return View();
        }

        public ActionResult Login(int id)
        {
            return View();
        }

        
    }
}