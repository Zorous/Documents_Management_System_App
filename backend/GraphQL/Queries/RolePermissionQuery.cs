using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class RolePermissionQuery
    {
        private readonly AppDbContext _context;

        // Constructor to inject AppDbContext
        public RolePermissionQuery(AppDbContext context)
        {
            _context = context;
        }

        // Resolver to get a list of role permissions
        public async Task<IEnumerable<RolePermission>> GetRolePermissions()
        {
            return await _context.RolePermissions
                                 .Include(rp => rp.Role)       // Include Role in the query
                                 .Include(rp => rp.Permission) // Include Permission in the query
                                 .ToListAsync();
        }

        // Resolver to get a role permission by ID
        public async Task<RolePermission?> GetRolePermissionById(int id)
        {
            return await _context.RolePermissions
                                 .Include(rp => rp.Role)       // Include Role in the query
                                 .Include(rp => rp.Permission) // Include Permission in the query
                                 .FirstOrDefaultAsync(rp => rp.RolePermissionId == id);
        }
    }
}
