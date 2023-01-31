using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AdamsShop.Utilities
{
    public class MyAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("Id") == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "UserManagement" }, { "Action", "MyLogin" }, { "returnUrl", filterContext.HttpContext.Request.Path } });
            }

            //filterContext.HttpContext.Response.StatusCode = HttpStatusCode.Forbidden;
        }
    }
}
