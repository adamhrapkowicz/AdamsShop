using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AdamsShopDbContext _adamsShopDbContext;
        private readonly IShoppingCartProvider _shoppingCartProvider;

        public OrderRepository(AdamsShopDbContext adamsShopDbContext, IShoppingCartProvider shoppingCartProvider)
        {
            _adamsShopDbContext = adamsShopDbContext;
            _shoppingCartProvider=shoppingCartProvider;
        }

        public void CreateOrder(Order order, Guid shoppingCartId)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCartProvider.GetShoppingCartItems(shoppingCartId);

            order.OrderTotal = _shoppingCartProvider.GetCartTotal(shoppingCartId);

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount= shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            _adamsShopDbContext.Orders.Add(order);
            _adamsShopDbContext.SaveChanges();
        }
    }
}
