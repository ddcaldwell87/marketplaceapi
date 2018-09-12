using Marketplace.Models;
using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public CustomerDetails GetCustomerById(int CustomerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == CustomerId && e.OwnerId == _userId);
                return
                    new CustomerDetails
                    {
                        CustomerId = entity.CustomerId,
                        CustomerFirstName = entity.CustomerFirstName,
                        CustomerLastName = entity.CustomerLastName,
                        CustomerEmail = entity.CustomerEmail,
                        ShippingInformation = entity.ShippingInformation,
                        CustomerPhone = entity.CustomerPhone,
                    };
            }
        }
    }
}
