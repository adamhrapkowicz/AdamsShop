using AdamsShop.Models;
using AdamsShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdamsShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartProvider _shoppingCartProvider;

        public ShoppingCartSummary(IShoppingCartProvider shoppingCart)
        {
            _shoppingCartProvider = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var shoppingCartIdString = HttpContext.Session.GetString("CartId");


            var shoppingCart = shoppingCartIdString == null
                ? CreateShoppingCart()
                : _shoppingCartProvider.GetShoppingCart(shoppingCartIdString);

            var shoppingCartViewModel = new ShoppingCartViewModel(shoppingCart);
            return View(shoppingCartViewModel);

            //// ?? throw new Exception("No shopping cart!");
            //if (shoppingCartIdString != null)
            //{
            //    var shoppingCartId = Guid.Parse(shoppingCartIdString);

            //    //var shoppingCart = _shoppingCartProvider.GetOrCreateCart(HttpContext);

            //    var shoppingCartViewModel = new ShoppingCartViewModel(
            //        _shoppingCartProvider.GetShoppingCart(shoppingCartIdString), _shoppingCartProvider.GetCartTotal(shoppingCartId));
            //    return View(shoppingCartViewModel);
            //}
            //else
            //{
            //    //var shoppingCartViewModel = new ShoppingCartViewModel(null, );
            //    return View(shoppingCartViewModel);
            //}

        }

        private DataModel.ShoppingCart CreateShoppingCart()
        {
            var shoppingCart = _shoppingCartProvider.CreateShoppingCart();
            HttpContext.Session.SetString("CartId", shoppingCart.ShoppingCartId.ToString());

            return shoppingCart;

        }
    }
}
