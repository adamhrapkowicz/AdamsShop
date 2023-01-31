using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public class MyRoleRepository : IMyRoleRepository
    {
        private readonly AdamsShopDbContext _adamsShopDbContext;

        public MyRoleRepository(AdamsShopDbContext adamsShopDbContext)
        {
            _adamsShopDbContext = adamsShopDbContext;
        }

        public void CreateMyRole(MyRole myRole)
        {
            _adamsShopDbContext.MyRoles.Add(myRole);
            _adamsShopDbContext.SaveChanges();
        }

        public List<MyRole> GetAllRoles()
        {
            return _adamsShopDbContext.MyRoles.ToList();
        }

        public void RemoveMyRole(MyRole myRole)
        {
            _adamsShopDbContext.MyRoles.Remove(myRole);
            _adamsShopDbContext.SaveChanges();
        }
    }
}
