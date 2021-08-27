using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using UserApplication.Models;

[assembly: OwinStartupAttribute(typeof(UserApplication.Startup))]
namespace UserApplication
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreatDefaultUsersAndRoles();
        }
        public void CreatDefaultUsersAndRoles()
        {

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!rolemanager.RoleExists("Admin"))
            {
                role.Name = "Admin";
                rolemanager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.EmailConfirmed = true;
                user.RegistrationDate = DateTime.Now;
                var check = usermanager.Create(user, "admin2018");
                if (check.Succeeded)
                {
                    usermanager.AddToRole(user.Id, "Admin");
                }
            }
            if (!rolemanager.RoleExists("Users"))
            {
                IdentityRole roleuser = new IdentityRole();
                roleuser.Name = "Users";
                rolemanager.Create(roleuser);

            }
        }
    }
}
