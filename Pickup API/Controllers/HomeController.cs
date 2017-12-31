using Pickup_API.App_Start;
using Pickup_Entity;
using Pickup_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Pickup_API.Controllers
{
    public class HomeController : ApiController
    {
        // GET: Home
        IProductService productService;

        public HomeController()
        {
            productService = Injector.Container.Resolve<IProductService>();
        }

        public IHttpActionResult Get()
        {
            List<Product> products = productService.GetAll();

            if (products == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(products);
        }

        public IHttpActionResult GetDetails([FromUri]int id)
        {
            Product product = productService.Get(id);

            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(product);
        }


    }
}