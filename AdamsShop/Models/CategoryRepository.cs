using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AdamsShopDbContext _adamsShopDbContext;

        public CategoryRepository(AdamsShopDbContext adamsShopDbContext)
        {
            _adamsShopDbContext=adamsShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _adamsShopDbContext.Categories.OrderBy(c => c.CategoryName); 
    }
}
