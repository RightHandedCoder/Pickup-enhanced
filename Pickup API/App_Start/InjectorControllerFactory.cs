﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pickup_API.App_Start
{
    public class InjectorControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (Controller)Injector.Container.Resolve(controllerType.FullName);
        }
    }
}