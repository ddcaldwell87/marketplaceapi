using Marketplace.Models.Customer;
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
    public class CustomerController : ApiController
    {
        //[Authorize(Roles = "Admin")]
        public IHttpActionResult GetAll()
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetAllCustomers();
            return Ok(customers);
        }

        public IHttpActionResult Get(int id)
        {
            CustomerService customerService = CreateCustomerService();
            var customer = customerService.GetCustomerById(id);
            return Ok(customer);
        }

        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.CreateCustomer(customer))
                return InternalServerError();

            return Ok();
        }

        //public IHttpActionResult Put(CustomerEdit customer)
        //{
        //    return Ok();
        //}

        //public IHttpActionResult Delete(CustomerDelete customer)
        //{
        //    return Ok();
        //}

        private CustomerService CreateCustomerService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(ownerId);
            return service;
        }
    }
}
