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
        AdminRepository adminRepo = new AdminRepository();
        Repository<Area> areaRepo = new Repository<Area>();
        Repository<Department> deptRepo = new Repository<Department>();
        Repository<Product> productRepo = new Repository<Product>();
        Repository<Catagory> catagoryRepo = new Repository<Catagory>();
        UserRepository<Seller> sellerRepo = new UserRepository<Seller>();
        UserRepository<Buyer> buyerRepo = new UserRepository<Buyer>();

        // GET: Admin
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            else return View(adminRepo.Get(id));
        }

        public ActionResult ViewUsers(int? id)
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

            else return RedirectToAction("Index","Home");
        }

        public ActionResult Logout()
        {
            Session["USER"] = null;
            Session["USERID"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            List<SelectListItem> areaList = new List<SelectListItem>();
            List<SelectListItem> deptList = new List<SelectListItem>();

            foreach (Area area in areaRepo.GetAll())
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = area.Id.ToString(),
                    Text = area.AreaName
                };

                areaList.Add(item);
            }

            foreach (Department dept in deptRepo.GetAll())
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = dept.Id.ToString(),
                    Text = dept.DepartmentName
                };

                deptList.Add(item);
            }

            ViewBag.AreaList = areaList;
            ViewBag.DeptList = deptList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (adminRepo.Insert(admin) == 1)
                {
                    return RedirectToAction("Index", "Admin", new { id = Session["USERID"] });
                }

                else return Create(admin);
            }

            else return View("Error");
        }

        public ActionResult BuyersList()
        { 
            return View(buyerRepo.GetAll());
        }

        public ActionResult BuyerDetails(int id)
        {
            UserRepository<Buyer> buyerRepo = new UserRepository<Buyer>();

            return View(buyerRepo.Get(id));
        }

        public ActionResult SellersList()
        {
            return View(sellerRepo.GetAll());
        }

        public ActionResult SellerDetails(int id)
        {
            UserRepository<Seller> sellerRepo = new UserRepository<Seller>();

            return View(sellerRepo.Get(id));
        }

        public ActionResult ProductsList()
        {
            ProductRepository productRepo = new ProductRepository();

            return View(productRepo.GetAll());
        }

        public ActionResult ProductDetails(int id)
        {
            ProductRepository productRepo = new ProductRepository();

            return View(productRepo.Get(id));
        }

        [HttpGet]
        public ActionResult CreateArea()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateArea(Area area)
        {
            Repository<Area> areaRepo = new Repository<Area>();

            if (ModelState.IsValid)
            {
                if (areaRepo.Insert(area) == 1)
                {
                    return RedirectToAction("Index", "Admin", new { id = Session["USERID"] });
                }

                else return View("Error");
            }

            else return View(area);
        }

        [HttpPost]
        public ActionResult CreateDepartment(Department dept)
        {
            Repository<Department> deptRepo = new Repository<Department>();

            if (ModelState.IsValid)
            {
                if (deptRepo.Insert(dept) == 1)
                {
                    return RedirectToAction("Index", "Admin", new { id = Session["USERID"] });
                }

                else return View("Error");
            }

            else return View(dept);
        }
    }
}