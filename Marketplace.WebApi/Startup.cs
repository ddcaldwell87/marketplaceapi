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
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
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

                var userAdmin = new ApplicationUser();
                userAdmin.UserName = "Admin";
                userAdmin.Email = "admin@admin.com";
                string passwordAdmin = "P@ssw0rd";
                var checkUserAdmin = userManager.Create(userAdmin, passwordAdmin);
                if (checkUserAdmin.Succeeded)
                {
                    userManager.AddToRole(userAdmin.Id, "Admin");
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
