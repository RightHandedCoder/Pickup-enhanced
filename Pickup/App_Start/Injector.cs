using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Injection;
using Injection.Interfaces;
using Pickup_Service;

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
            
        }
    }
}