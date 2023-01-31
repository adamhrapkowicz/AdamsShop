using AdamsShop.DataModel;
using Microsoft.EntityFrameworkCore;

namespace AdamsShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AdamsShopDbContext _adamsShopDbContext;

        public PieRepository(AdamsShopDbContext adamsShopDbContext)
        {
            _adamsShopDbContext=adamsShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _adamsShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _adamsShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _adamsShopDbContext.Pies.FirstOrDefault(p =>p.PieId== pieId);            
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
