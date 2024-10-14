using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class PermissionQuery
    {
        private readonly AppDbContext _context;

        // Constructor to inject AppDbContext
        public PermissionQuery(AppDbContext context)
        {
            _context = context;
        }

        // Resolver to get a list of permissions
        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            return await _context.Permissions.ToListAsync();
        }

        // Resolver to get a permission by ID
        public async Task<Permission?> GetPermissionById(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }
    }
}
