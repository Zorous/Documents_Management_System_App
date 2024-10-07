using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class PermissionQuery
    {

        // Resolver to get a list of permissions
        public async Task<IEnumerable<Permission>> GetPermissions([Service] AppDbContext dbContext)
        {
            return await dbContext.Permissions.ToListAsync();
        }

        // Resolver to get a permission by ID
        public async Task<Permission?> GetPermissionById(int id, [Service] AppDbContext dbContext)
        {
            return await dbContext.Permissions.FindAsync(id);
        }
    }
}
