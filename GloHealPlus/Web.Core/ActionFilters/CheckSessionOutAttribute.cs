using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Core.ActionFilters
{
    public class CheckSessionOutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower().Trim();
            string actionName = filterContext.ActionDescriptor.ActionName.ToLower().Trim();
            if (!controllerName.StartsWith("login", System.StringComparison.InvariantCultureIgnoreCase)
                && !controllerName.StartsWith("home", System.StringComparison.InvariantCultureIgnoreCase)

                )
            {
                var session = HttpContext.Current.Session["UserId"];
                HttpContext ctx = HttpContext.Current;
                if (session == null)
                {
                    HttpContext.Current.Session["SessionNull"] = "Exception Message";
                    base.OnActionExecuting(filterContext);
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        area = "",
                        controller = "Login",
                        action = "Login"
                    }));
                }
            }

        }
    }
}
