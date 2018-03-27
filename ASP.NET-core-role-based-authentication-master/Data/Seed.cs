using System;
using System.Threading.Tasks;
using ASP.NET_core_role_based_authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NET_core_role_based_authentication.Data
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
          
            string[] roleNames = { "Admin", "Manager", "Member" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            string username = Configuration.GetSection("AppSettings")["UserEmail"];
            string email = Configuration.GetSection("AppSettings")["UserEmail"];
            string password= Configuration.GetSection("AppSettings")["UserPassword"];
            await CreatePowerUser(serviceProvider,Configuration, username, email,password);
            //creating a super user who could maintain the web app
           

          
        }

        public static async Task CreatePowerUser(IServiceProvider serviceProvider, IConfiguration Configuration,string username,string email,string password)
        {

            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var poweruser = new ApplicationUser
            {
                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
                Email = Configuration.GetSection("AppSettings")["UserEmail"]
            };

            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);

            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }
    }
}