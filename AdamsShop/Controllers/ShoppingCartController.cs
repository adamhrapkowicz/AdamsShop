using AdamsShop.Models;
using AdamsShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace AdamsShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IShoppingCartProvider _shoppingCartProvider;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCartProvider shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCartProvider = shoppingCart;
        }

        public ViewResult Index()
        {
            var shoppingCartIdString = HttpContext.Session.GetString("CartId")
                    ?? throw new Exception("No shopping cart!");

            var shoppingCartId = Guid.Parse(shoppingCartIdString);

            //var shoppingCart = _shoppingCartProvider.GetOrCreateCart(HttpContext);

            var shoppingCartViewModel = new ShoppingCartViewModel(
                _shoppingCartProvider.GetShoppingCart(shoppingCartIdString));

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var shoppingCartIdString = HttpContext.Session.GetString("CartId")
                    ?? throw new Exception("No shopping cart!");
            var shoppingCartId = Guid.Parse(shoppingCartIdString);
            //var shoppingCart = _shoppingCartProvider.GetShoppingCart(Guid.Parse(shoppingCart);

            _shoppingCartProvider.AddToCart(id, shoppingCartId);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var shoppingCartIdString = HttpContext.Session.GetString("CartId")
                    ?? throw new Exception("No shopping cart!");

            var shoppingCartId = Guid.Parse(shoppingCartIdString);

            //var shoppingCart = _shoppingCartProvider.GetShoppingCart(HttpContext);

            _shoppingCartProvider.RemoveFromCart(id, shoppingCartId);

            return RedirectToAction("Index");
        }
    }
}
