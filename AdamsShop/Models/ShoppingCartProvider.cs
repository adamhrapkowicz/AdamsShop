using AdamsShop.DataModel;
using Microsoft.EntityFrameworkCore;

namespace AdamsShop.Models
{
    public class ShoppingCartProvider : IShoppingCartProvider
    {
        private readonly AdamsShopDbContext _adamsShopDbContext;

        public ShoppingCartProvider(AdamsShopDbContext adamsShopDbContext)
        {
            _adamsShopDbContext = adamsShopDbContext;
        }

        public ShoppingCart CreateShoppingCart()
        {
            var newShoppingCart = new ShoppingCart();
            _adamsShopDbContext.ShoppingCart.Add(newShoppingCart);
            _adamsShopDbContext.SaveChanges();

            return newShoppingCart;
        }

        public ShoppingCart GetShoppingCart(string shoppingCartId)
        {
            if (shoppingCartId == null)
                 throw new NullReferenceException($"soppingCartId cannot be null!");

            return _adamsShopDbContext.ShoppingCart
                .Include(p => p.ShoppingCartItems).ThenInclude(p => p.Pie)
                .FirstOrDefault(p => p.ShoppingCartId == Guid.Parse(shoppingCartId))
                 ?? throw new Exception($"Sopping cart with ID {shoppingCartId} was not found!");
        }

        public void AddToCart(int pieId, Guid ShoppingCartId)
        {
            var pie =
               _adamsShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId)
               ?? throw new Exception("Something is not right!");

            var shoppingCartItem = _adamsShopDbContext.ShoppingCartItems.FirstOrDefault(
                s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };
                _adamsShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _adamsShopDbContext.SaveChanges();
        }

        public void ClearCart(Guid shoppingCartId)
        {
            var cartItems = _adamsShopDbContext.ShoppingCartItems.Where(
                cart => cart.ShoppingCartId == shoppingCartId);

            _adamsShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _adamsShopDbContext.SaveChanges();
        }

        public decimal GetCartTotal(Guid shoppingCartId)
        {
            var total = _adamsShopDbContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == shoppingCartId).Select(c => c.Pie.Price * c.Amount).Sum();

            return total;
        }

        public List<ShoppingCartItem> GetShoppingCartItems(Guid shoppingCartId)
        {
            return _adamsShopDbContext.ShoppingCartItems.Where(
                c => c.ShoppingCartId == shoppingCartId).Include(s => s.Pie).ToList();
        }

        public int RemoveFromCart(int pieId, Guid shoppingCartId)
        {
            var shoppingCartItem = _adamsShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Pie.PieId == pieId && s.ShoppingCartId == shoppingCartId);
            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _adamsShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
                _adamsShopDbContext.SaveChanges();
            }

            return localAmount;
        }
    }
}
