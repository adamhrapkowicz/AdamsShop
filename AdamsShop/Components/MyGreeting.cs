using Microsoft.AspNetCore.Mvc;

namespace AdamsShop.Components
{
    public class MyGreeting : ViewComponent 
    {
        public MyGreeting()
        {
        }

        public IViewComponentResult Invoke()
        {
            var greetedUser = Request.HttpContext.Session.GetString("MyUserName");
            ViewData["user"] = greetedUser;
            return View();
        }
    }
}
