using Hospital_Management.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospital_Management.Startup))]
namespace Hospital_Management
{
    public partial class Startup
    {
        private ApplicationDbContext context;
        public Startup()
        {
            context = new ApplicationDbContext();
        }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateRoles();
            //CreateUsers();
        }
        public void CreateUsers()
        {
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var user = new ApplicationUser();
            //user.Email = "doctor@gmail.com";
            //user.UserName = "doctor";
            //var check = userManager.Create(user, "01143511772@Kr");

            //if (check.Succeeded)
            //{
            //    userManager.AddToRole(user.Id, "Doctors");
            //}
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser();
            user.Email = "patient@gmail.com";
            user.UserName = "patient";
            var check = userManager.Create(user, "01143511772@Kr");

            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Patients");
            }
        }
        public void CreateRoles()
        {
            //IdentityRole object to add new role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityRole role;
            if (!roleManager.RoleExists("Doctors"))
            {
                role = new IdentityRole { Name = "Doctors" };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Patients"))
            {
                role = new IdentityRole { Name = "Patients" };
                roleManager.Create(role);
            }
           
        }
    }
}
