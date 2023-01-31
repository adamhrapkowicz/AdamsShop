using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order, Guid shoppingCartId);
    }
}
