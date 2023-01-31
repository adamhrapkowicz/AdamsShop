using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public interface IRoleAssignedToUserRepository
    {
        public void AssignRoleToUser(RoleAssignedToUser roleAssignedToUser);

        public void RemoveRoleFromUser(RoleAssignedToUser roleAssignedToUser);

        List<RoleAssignedToUser> GetAllRolesAssignedToUsers();

        List<RoleAssignedToUser> GetRolesAssignedToOneUser(int UserId);

    }
}
