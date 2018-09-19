using Marketplace.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Contracts
{
    public interface IAdminService
    {
        bool IsAdminUser();
        IEnumerable<ApplicationUser> GetUserList();
        IEnumerable<IdentityRole> GetRolesList();
        IEnumerable<Retailer> GetRetailers();
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Product> GetProducts();
    }
}
