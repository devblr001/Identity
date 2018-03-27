using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_core_role_based_authentication.Models
{
    public class GroupedUserViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<UserViewModel> Admins { get; set; }
    }
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
