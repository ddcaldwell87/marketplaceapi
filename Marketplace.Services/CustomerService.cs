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
        private readonly int _CustomerID;   


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
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
               new Customer
               {
                   CustomerId = _CustomerID,
                   CustomerFirstName = model.CustomerFirstName,
                   CustomerLastName = model.CustomerLastName,
                   CustomerEmail = model.CustomerEmail,
                   CustomerPhone = model.CustomerPhone,
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }



        public ICollection<CustomerListItem> GetAllCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customers =
                    ctx
                        .Customers
                        .Select(
                            e => new CustomerListItem()
                            {
                                
                                CustomerId = e.CustomerId,
                                CustomerFirstName= e.CustomerFirstName,
                                CustomerLastName= e.CustomerLastName,
                                CustomerEmail = e.CustomerEmail,
                                CustomerPhone = e.CustomerPhone,
                            });

                return customers.ToList();
            }
        }
    }
}
