using HotChocolate;
using backend.Models;
using backend.Database;

namespace backend.GraphQL.Mutations
{
    public class RolePermissionMutations
    {
        public async Task<RolePermission> CreateRolePermissionAsync([Service] AppDbContext context, RolePermission rolePermission)
        {
            context.RolePermissions.Add(rolePermission);
            await context.SaveChangesAsync();
            return rolePermission;
        }

        public async Task<RolePermission> UpdateRolePermissionAsync([Service] AppDbContext context, RolePermission rolePermission)
        {
            context.RolePermissions.Update(rolePermission);
            await context.SaveChangesAsync();
            return rolePermission;
        }

        public async Task<bool> DeleteRolePermissionAsync([Service] AppDbContext context, int rolePermissionId)
        {
            var rolePermission = await context.RolePermissions.FindAsync(rolePermissionId);
            if (rolePermission == null) return false;

            context.RolePermissions.Remove(rolePermission);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
