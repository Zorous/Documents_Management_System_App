using HotChocolate;
using backend.Models;
using backend.Database;

namespace backend.GraphQL.Mutations
{
    public class RoleMutations
    {
        public async Task<Role> CreateRoleAsync([Service] AppDbContext context, Role role)
        {
            context.Roles.Add(role);
            await context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRoleAsync([Service] AppDbContext context, Role role)
        {
            context.Roles.Update(role);
            await context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRoleAsync([Service] AppDbContext context, int roleId)
        {
            var role = await context.Roles.FindAsync(roleId);
            if (role == null) return false;

            context.Roles.Remove(role);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
