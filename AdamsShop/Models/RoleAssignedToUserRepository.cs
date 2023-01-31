using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public class RoleAssignedToUserRepository : IRoleAssignedToUserRepository
    {
        private readonly AdamsShopDbContext _adamsShopDbContext;

        public RoleAssignedToUserRepository(AdamsShopDbContext adamsShopDbContext)
        {
            _adamsShopDbContext = adamsShopDbContext;
        }

        public void AssignRoleToUser(RoleAssignedToUser roleAssignedToUser)
        {
            if (!_adamsShopDbContext.RoleAssignedToUsers.Any(u => u.MyUser == roleAssignedToUser.MyUser && u.MyRole == roleAssignedToUser.MyRole))
            {
                _adamsShopDbContext.RoleAssignedToUsers.Add(roleAssignedToUser); 
                _adamsShopDbContext.SaveChanges();
            }
            throw new Exception("This user has been already assigned to the role.");
        }

        public List<RoleAssignedToUser> GetAllRolesAssignedToUsers()
        {
            return _adamsShopDbContext.RoleAssignedToUsers.ToList();
        }

        public void RemoveRoleFromUser(RoleAssignedToUser roleAssignedToUser)
        {
            if (_adamsShopDbContext.RoleAssignedToUsers.Any(u => u.MyUser == roleAssignedToUser.MyUser && u.MyRole == roleAssignedToUser.MyRole))
            {
                _adamsShopDbContext.RoleAssignedToUsers.Remove(roleAssignedToUser);
                _adamsShopDbContext.SaveChanges();
            }
            throw new Exception("This user hasn't been assigned to the role."); 
        }

        public List<RoleAssignedToUser> GetRolesAssignedToOneUser(int UserId)
        {
            return _adamsShopDbContext.RoleAssignedToUsers.Where(u => u.MyUser.UserId == UserId).ToList();
        }
    }
}
