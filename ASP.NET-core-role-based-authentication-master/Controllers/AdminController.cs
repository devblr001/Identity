
using ASP.NET_core_role_based_authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASP.NET_core_role_based_authentication.Controllers
{
	// [Authorize(Roles="Admin")]
	[Authorize(Policy = "RequireAdminRole")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
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

        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddRole(IFormCollection collection)
        {
            string role = collection["RoleName"];
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
            return Json(_roleManager.Roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(string email, string[] roles)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                if (!User.IsInRole(role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            return Json(await _userManager.GetRolesAsync(user));
        }

        public JsonResult GetRoleList()
        {

            return Json(_roleManager.Roles);//, JsonRequestBehavior.AllowGet);
        }
    }

    }



