﻿using Marketplace.Contracts;
using Marketplace.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Services
{
    public class AdminService : IAdminService
    {
        private readonly Guid _userId;

        public AdminService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Retailer> GetRetailers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentityRole> GetRolesList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var rolesList = ctx.Roles.ToList();
                return rolesList.ToArray();
            }
        }

        public IEnumerable<ApplicationUser> GetUserList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userList = ctx.Users.ToList();
                return userList.ToArray();
            }
        }

        public bool IsAdminUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                    var s = userManager.GetRoles(_userId.ToString());
                    if (s.Count != 0 && s[0].ToString() == "Admin")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
