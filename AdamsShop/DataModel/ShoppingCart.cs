namespace AdamsShop.DataModel
{
    public class ShoppingCart
    {
        public Guid ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new();
    }
}
