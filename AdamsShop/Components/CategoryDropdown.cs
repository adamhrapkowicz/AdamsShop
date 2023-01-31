using AdamsShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdamsShop.Components
{
    public class CategoryDropdown : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDropdown(ICategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName);

            return View(categories);
        }
    }
}
