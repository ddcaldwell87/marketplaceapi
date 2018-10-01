using Marketplace.Models.Product;
using Marketplace.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marketplace.WebApi.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ProductService productService = CreateProductService();
            var products = productService.GetAllProducts();
            return Ok(products);
        }

        public IHttpActionResult Get(int id)
        {
            ProductService productService = CreateProductService();
            var product = productService.GetProductbyId(id);
            return Ok(product);
        }

        public IHttpActionResult Post(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService(product);

            if (!service.CreateProduct(product))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ProductEdit product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();

            if (!service.UpdateProduct(product))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();

            if (!service.DeleteProduct(id))
                return InternalServerError();

            return Ok();
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductService(userId);
            return productService;
        }

        private ProductService CreateProductService(ProductCreate product)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductService(userId, product.RetailerId);
            return productService;
        }
    }
}
