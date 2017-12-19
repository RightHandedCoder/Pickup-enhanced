using Pickup_Entity;
using Pickup_Repository;
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
        IService<Product> service = new Service<Product>();

        public IHttpActionResult Get()
        {
            List<Product> products = service.GetAll();

            if (products == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(products);
        }

        public IHttpActionResult GetDetails([FromUri]int id)
        {
            Product product = service.Get(id);

            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(product);
        }


    }
}