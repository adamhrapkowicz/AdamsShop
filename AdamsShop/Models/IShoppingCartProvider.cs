using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public interface IShoppingCartProvider
    {
        ShoppingCart CreateShoppingCart();

        ShoppingCart GetShoppingCart(string shoppingCartId);

        void AddToCart(int pieId, Guid shoppingCartId);

        int RemoveFromCart(int pieId, Guid shoppingCartId);

        List<ShoppingCartItem> GetShoppingCartItems(Guid shoppingCartId);

        void ClearCart(Guid shoppingCartId);

        decimal GetCartTotal(Guid shoppingCartId);
    }
}
