using backend.Database;
using backend.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Mutations
{
    public class PermissionMutations
    {
        private readonly AppDbContext _context;

        public PermissionMutations(AppDbContext context)
        {
            _context = context;
        }

        // Create Permission
        public async Task<Permission> CreatePermission(string permissionName)
        {
            var permission = new Permission
            {
                PermissionName = permissionName,
                CreatedAt = DateTime.UtcNow
            };

            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        // Update Permission
        public async Task<Permission> UpdatePermission(int permissionId, string permissionName)
        {
            var permission = await _context.Permissions.FindAsync(permissionId);
            if (permission == null) throw new Exception("Permission not found.");

            permission.PermissionName = permissionName;
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
            return permission;
        }

        // Delete Permission
        public async Task<bool> DeletePermission(int permissionId)
        {
            var permission = await _context.Permissions.FindAsync(permissionId);
            if (permission == null) throw new Exception("Permission not found.");

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
