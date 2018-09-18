using Marketplace.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Contracts
{
    public interface ICustomerService
    {
        CustomerDetails GetCustomerById(int customerId);
        bool UpdateCustomer(CustomerEdit model);
        bool CreateCustomer(CustomerCreate model);
        bool DeleteCustomer(int customerid);
        ICollection<CustomerListItem> GetAllCustomers();
    }
}
