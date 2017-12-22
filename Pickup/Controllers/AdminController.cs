using Oracle_Repository;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class AdminController : Controller
    {
        UserRepository<Admin> adminRepo = new UserRepository<Admin>();

        // GET: Admin
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            else return View(adminRepo.Get(id));
        }

        public ActionResult ViewUsers(int id)
        {
            if (id == 1)
            {
                UserRepository<Buyer> buyerRepo = new UserRepository<Buyer>();

                return View("ViewUsers_Buyer", buyerRepo.GetAll());
            }

            else if (id == 2)
            {
                UserRepository<Seller> sellerRepo = new UserRepository<Seller>();

                return View("ViewUsers_Seller", sellerRepo.GetAll());
            }

            else return View("Error");
        }

        public ActionResult Logout()
        {
            Session["USER"] = null;
            Session["USERID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}