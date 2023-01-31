using Microsoft.AspNetCore.Mvc;

namespace AdamsShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
