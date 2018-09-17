using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Marketplace.WebApi.Startup))]

namespace Marketplace.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                var userBailey = new ApplicationUser();
                userBailey.UserName = "Bailey";
                userBailey.Email = "Bailey@admin.com";
                string passwordBailey = "P@ssw0rd";
                var checkUserBailey = userManager.Create(userBailey, passwordBailey);
                if (checkUserBailey.Succeeded)
                {
                    var result = userManager.AddToRole(userBailey.Id, "Admin");
                }

                var userHarrison = new ApplicationUser();
                userHarrison.UserName = "Harrison";
                userHarrison.Email = "Harrison@admin.com";
                string passwordHarrison = "P@ssw0rd";
                var checkUserHarrison = userManager.Create(userHarrison, passwordHarrison);
                if (checkUserHarrison.Succeeded)
                {
                    var result = userManager.AddToRole(userHarrison.Id, "Admin");
                }

                var userShiv = new ApplicationUser();
                userShiv.UserName = "Shiv";
                userHarrison.Email = "Shiv@admin.com";
                string passwordShiv = "P@ssw0rd";
                var checkUserShiv = userManager.Create(userShiv, passwordShiv);
                if (checkUserShiv.Succeeded)
                {
                    var result = userManager.AddToRole(userShiv.Id, "Admin");
                }

                var userDavid = new ApplicationUser();
                userDavid.UserName = "David";
                userDavid.Email = "David@admin.com";
                string passwordDavid = "P@ssw0rd";
                var checkUserDavid = userManager.Create(userDavid, passwordDavid);
                if (checkUserDavid.Succeeded)
                {
                    var result = userManager.AddToRole(userDavid.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("Retailer"))
            {
                var role = new IdentityRole();
                role.Name = "Retailer";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
