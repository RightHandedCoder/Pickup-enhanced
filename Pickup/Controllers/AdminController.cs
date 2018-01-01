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
        IAdminService service;

        public AdminController()
        {
            service = Injector.Container.Resolve<IAdminService>();
        }

        public ActionResult Index(int id)
        {
            Admin admin = service.Get(id);

            return View(admin);
        }
    }
}