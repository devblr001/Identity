
using ASP.NET_core_role_based_authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_core_role_based_authentication.Controllers
{
	// [Authorize(Roles="Admin")]
	[Authorize(Policy = "RequireAdminRole")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public ActionResult UserDetails()
        {

            var applicationUsers = new ApplicationUser().GetUserDetails();
          //  var model = new GroupedUserViewModel { Users = applicationUsers.Item1, Admins = applicationUsers.Item2 };
            return View(applicationUsers);
        }
    }



}