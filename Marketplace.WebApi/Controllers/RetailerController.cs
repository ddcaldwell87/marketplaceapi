using Marketplace.Models;
using Marketplace.Models.Retailer;
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
    public class RetailerController : ApiController
    {   
        public IHttpActionResult GetAll()
        {
            RetailerService RetailerService = CreateRetailerService();
            var retailer = RetailerService.GetAllRetailers();
            return Ok(retailer);
        }
        public IHttpActionResult Get(int id)
        {
            RetailerService customerService = CreateRetailerService();
            var retailer = customerService.GetRetailerbyId(id);
            return Ok(retailer);
        }
        public IHttpActionResult Post(RetailerCreate retailer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRetailerService();

            if (!service.CreateRetailer(retailer))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(RetailerEdit retailer)
        {   
            if (!ModelState.IsValid)
                return BadRequest(ModelState);  

            var service = CreateRetailerService();

            if (!service.UpdateRetailer(retailer))
            {
                return InternalServerError();
            }
                  

            return Ok();
        }

        private RetailerService CreateRetailerService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new RetailerService(ownerId);
            return service;
        }
    }
}


