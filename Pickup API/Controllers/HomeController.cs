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

        [ActionName("Details")]
        public IHttpActionResult Get([FromUri]int id)
        {
            Product product = productService.Get(id);

            if (product == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(product);
        }

        [ActionName("AddProduct")]
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (productService.Insert(product) == 1)
                {
                    return StatusCode(HttpStatusCode.Created);
                }

                else return StatusCode(HttpStatusCode.Gone);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        [ActionName("EditProduct")]
        public IHttpActionResult Put([FromBody]Product product, [FromUri]int id)
        {
            product.Id = id;

            try
            {
                productService.Update(product);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.NotModified);
            }
        }

        public IHttpActionResult Delete([FromUri]int id)
        {
            Product product = productService.Get(id);

            if (product==null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            else
            {
                try
                {
                    productService.Delete(product);
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(HttpStatusCode.BadRequest);
                }
            }
        }
    }
}