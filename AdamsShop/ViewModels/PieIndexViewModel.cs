using AdamsShop.DataModel;

namespace AdamsShop.ViewModels
{
    public class PieIndexViewModel
    {
        public IEnumerable<Pie> Pies { get; }

        public string? CurrentCategory { get; }

        public PieIndexViewModel(IEnumerable<Pie> pies, string? currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }

    }
}
