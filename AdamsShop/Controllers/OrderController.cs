using AdamsShop.DataModel;
using AdamsShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdamsShop.Controllers
{
    [MyAuthentication]

    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartProvider _shoppingCartProvider;

        public OrderController(IOrderRepository orderRepository, IShoppingCartProvider shoppingCartProvider)
        {
            _orderRepository = orderRepository;
            _shoppingCartProvider = shoppingCartProvider;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                var shoppingCartId = HttpContext.Session.GetString("CartId") 
                    ?? throw new Exception("No shopping cart!");

                var items = _shoppingCartProvider.GetShoppingCartItems(Guid.Parse(shoppingCartId));

                if (items.Count == 0)
                {
                    ModelState.AddModelError("", "Your shopping cart is empty. Please add some pies first");
                }

                _orderRepository.CreateOrder(order, Guid.Parse(shoppingCartId!));
                _shoppingCartProvider.ClearCart(Guid.Parse(shoppingCartId));
                return RedirectToAction("CheckoutCompleted");
            }

            return View(order);
        }

        private ShoppingCart CreateNewShoppingCart()
        {
            var shoppingCart = _shoppingCartProvider.CreateShoppingCart();
            HttpContext.Session.SetString("CartId", shoppingCart.ShoppingCartId.ToString());
            return shoppingCart;
        }

        public IActionResult CheckoutCompleted()
        {
            ViewBag.CheckoutCompletedMessage = "Thank you for your order. You will soon enjoy our delicious pies!";
            return View();
        }
    }
}
