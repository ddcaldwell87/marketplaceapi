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
                        .Customer
                        .Single(e => e.CustomerID == CustomerId && e.OwnerId == _userId);
                return
                    new CustomerDetails
                    {
                        CustomerId = entity.NoteId,
                        CustomerFirstName = entity.Title,
                        CUstomerLastName = entity.Content,
                        CustomerEmail = entity.CreatedUtc,
                        CustomerStreetAddress = entity.ModifiedUtc,
                        State = entity.State,
                        City = entity.City,
                        Zip = entity.Zip,
                        CustomerPhone = entity.CustomerPhone,
                        ShippingInformation = $"{entity.CustomerFirstName}" + $"{entity.CustomerLastName} \n" + $"{entity.CustomerStreetAddress}\n" + $"{entity.City}" + ", " + $"{entity.State}" + "" + $"{entity.Zip}",

                    };
            }
        }
    }
}
