using HotChocolate;
using backend.Models;
using backend.Database;

namespace backend.GraphQL.Mutations
{
    public class UserRoleMutations
    {
        public async Task<UserRole> CreateUserRoleAsync([Service] AppDbContext context, UserRole userRole)
        {
            context.UserRoles.Add(userRole);
            await context.SaveChangesAsync();
            return userRole;
        }

        public async Task<UserRole> UpdateUserRoleAsync([Service] AppDbContext context, UserRole userRole)
        {
            context.UserRoles.Update(userRole);
            await context.SaveChangesAsync();
            return userRole;
        }

        public async Task<bool> DeleteUserRoleAsync([Service] AppDbContext context, int userRoleId)
        {
            var userRole = await context.UserRoles.FindAsync(userRoleId);
            if (userRole == null) return false;

            context.UserRoles.Remove(userRole);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
