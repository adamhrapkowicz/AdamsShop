using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
