using Oracle_Repository;
using Pickup.Models;
using Pickup_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.Controllers
{
    public class SellerController : Controller
    {
        UserRepository<Seller> sellerRepo = new UserRepository<Seller>();
        Repository<Area> areaRepo = new Repository<Area>();
        Repository<Catagory> catagoryRepo = new Repository<Catagory>();
        CredentialRepository<SellerCredential> credentialRepo = new CredentialRepository<SellerCredential>();
        ProductRepository productRepo = new ProductRepository();

        // GET: Seller
        public ActionResult Index(int id)
        {
            return View(sellerRepo.Get(id));
        }

        public ActionResult Logout()
        {
            Session["USER"] = null;
            Session["USERID"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            return View(sellerRepo.Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> areaList = new List<SelectListItem>();

            foreach (var item in areaRepo.GetAll())
            {
                areaList.Add(new SelectListItem() {

                    Text=item.AreaName,
                    Value=item.Id.ToString()
                });

                ViewBag.AreaList = areaList;
            }

            return View(sellerRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Seller seller)
        {
            if (ModelState.IsValid)
            {
                if (sellerRepo.Update(seller) == 1)
                {
                    return RedirectToAction("Details", "Seller", new { id = seller.Id });
                }

                else return View("Error");
            }

            else return View(seller);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel credential)
        {
            SellerCredential oldCredential = credentialRepo.GetById((int)Session["USERID"]) as SellerCredential;

            if (credential.OldPassword == oldCredential.Password)
            {
                if (credential.NewPassword == credential.ConfirmPassword)
                {
                    SellerCredential newCredential = new SellerCredential() { Id = oldCredential.Id, Password = credential.NewPassword };

                    if (credentialRepo.UpdatePassword(newCredential) == 1)
                    {
                        return RedirectToAction("Index", "Seller", new { id = (int)Session["USERID"] });
                    }

                    else return View(credential);
                }

                else return View(credential);
            }

            else return View(credential);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> catagoryList = new List<SelectListItem>();

            foreach (var item in catagoryRepo.GetAll())
            {
                catagoryList.Add(new SelectListItem() {

                    Text = item.CatagoryName,
                    Value = item.Id.ToString()
                });
            }

            ViewBag.Catagory = catagoryList;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            product.SellerId = (int)Session["USERID"];

            if (ModelState.IsValid)
            {
                if (productRepo.Insert(product) == 1)
                {
                    return RedirectToAction("Index", "Home", new { id = (int)Session["USERID"] });
                }

                else return View("Error");
            }

            else return View(product);
        }
    }
}