using Marketplace.Models;
using Marketplace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Models.Customer;

namespace Marketplace.Services
{
    
    public class CustomerService
    {
        private readonly Guid _userId;
        private readonly int _customerID;   


        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public CustomerDetails GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);
                return
                    new CustomerDetails
                    {
                        CustomerId = entity.CustomerId,
                        CustomerFirstName = entity.CustomerFirstName,
                        CustomerLastName = entity.CustomerLastName,
                        CustomerEmail = entity.CustomerEmail,
                        CustomerPhone = entity.CustomerPhone,
                        CustomerStreetAddress = entity.CustomerStreetAddress,
                        State = entity.State,
                        City = entity.City,
                        Zip = entity.Zip
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId && e.OwnerId == _userId);
                entity.CustomerFirstName = model.CustomerFirstName;
                entity.CustomerLastName = model.CustomerLastName;
                entity.CustomerEmail = model.CustomerEmail;
                entity.CustomerPhone = model.CustomerPhone;
                entity.CustomerStreetAddress = model.CustomerStreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
               new Customer
               {
                   CustomerId = _customerID,
                   CustomerFirstName = model.CustomerFirstName,
                   CustomerLastName = model.CustomerLastName,
                   CustomerEmail = model.CustomerEmail,
                   CustomerPhone = model.CustomerPhone,
                   CustomerStreetAddress = model.CustomerStreetAddress,
                   State = model.State,
                   City = model.City,
                   Zip = model.Zip
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteCustomer(int customerid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerid && e.OwnerId == _userId);
                ctx.Customers.Remove(entity);
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
                                CustomerStreetAddress = e.CustomerStreetAddress,
                                State = e.State,
                                City = e.City,
                                Zip = e.Zip
                            });

                return customers.ToList();
            }
        }
    }
}
