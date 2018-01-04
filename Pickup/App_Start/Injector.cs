using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Injection;
using Injection.Interfaces;
using Pickup_Service;
using Pickup_Entity;

namespace Pickup.App_Start
{
    public class Injector
    {
        public static IInjectionContainer Container { get; set; }

        static Injector()
        {
            Container = new Container();
        }

        public static void Configure()
        {
            Container.Register<IAdminService, AdminService>().Singleton();
            Container.Register<IAreaService, AreaService>().Singleton();
            Container.Register<IBuyerService, BuyerService>().Singleton();
            Container.Register<ICatagoryService, CatagoryService>().Singleton();
            Container.Register<ICredentialService<BuyerCredential>, CredentialService<BuyerCredential>>().Singleton();
            Container.Register<ICredentialService<SellerCredential>, CredentialService<SellerCredential>>().Singleton();
            Container.Register<ICredentialService<AdminCredential>, CredentialService<AdminCredential>>().Singleton();
            Container.Register<IDepartmentService, DepartmentService>().Singleton();
            Container.Register<IProductService, ProductService>().Singleton();
            Container.Register<ISellerService, SellerService>().Singleton();
            Container.Register<IShoppingCartService, ShoppingCartService>().Singleton();
            Container.Register<IBuyerPurchaseService, BuyerPurchaseService>().Singleton();
        }
    }
}