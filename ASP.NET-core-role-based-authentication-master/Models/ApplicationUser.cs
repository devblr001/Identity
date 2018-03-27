using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_core_role_based_authentication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ASP.NET_core_role_based_authentication.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<UserViewModel> GetUserDetails()
        {

            string connectionString = "Server=localhost;Database=GlohealPlusAspId;Trusted_Connection=True;MultipleActiveResultSets=true";// ";//Configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                var lstUserRoleModel = new List<UserViewModel>();
                var users = (from u in context.Users
                             join ur in context.UserRoles on u.Id equals ur.UserId
                             join r in context.Roles on ur.RoleId equals r.Id
                             select new UserViewModel
                             {
                                 Email = u.Email,
                                 Username = u.UserName,
                                 RoleName = r.Name
                             }).ToList();

                return users;
            //    var role = (from r in context.Roles where r.Name.Contains("Admin") select r).FirstOrDefault();
            //    var users = context.UserRoles.Where(x => x.Select(y => y.RoleId).Contains(role.Id)).ToList();

            //    var userVM = users.Select(user => new UserViewModel
            //    {
            //        Username = user.UserName,
            //        Email = user.Email,
            //        RoleName = "Manager"
            //    }).ToList();

             

            //var role2 = (from r in context.Roles where r.Name.Contains("Mananger") select r).FirstOrDefault();
            //    var admins = context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role2.Id)).ToList();

            //    var adminVM = admins.Select(user => new UserViewModel
            //    {
            //        Username = user.UserName,
            //        Email = user.Email,
            //        RoleName = "Admin"
            //    }).ToList();


            //    var userRoles = new Tuple<List<UserViewModel>, List<UserViewModel>>(userVM, adminVM);
              //  return userRoles;
            }

         
          
        }
    }
}
