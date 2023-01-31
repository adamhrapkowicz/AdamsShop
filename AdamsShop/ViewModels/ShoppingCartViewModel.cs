using AdamsShop.DataModel;

namespace AdamsShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
        }

        public ShoppingCart ShoppingCart { get; }
        public decimal CartTotal => ShoppingCart.ShoppingCartItems.Select(c => c.Pie.Price * c.Amount).Sum();
    }
}
