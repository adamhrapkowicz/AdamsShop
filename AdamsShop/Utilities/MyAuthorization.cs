using AdamsShop.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdamsShop.Utilities
{
    public class MyAuthorization : ActionFilterAttribute
    {
        private readonly AdamsShopDbContext _adamsShopDbContext;

        public MyAuthorization(AdamsShopDbContext adamsShopDbContext)
        {
            _adamsShopDbContext = adamsShopDbContext;
        }

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //var authorizedUser = filterContext.HttpContext.User;
        //    var authorizedUser = filterContext.HttpContext.Session.GetString("MyUserName");
        //    var authorizedUserId = _adamsShopDbContext.MyUsers.FirstOrDefault(u => u. == authorizedUser);
        //    //var x = GetRolesAssignedToOneUser(filterContext.HttpContext.User);
        //    if (_adamsShopDbContext.RoleAssignedToUsers.Any(u => u.MyUser == authorizedUser ) != null) { }
        //}
    }
}
