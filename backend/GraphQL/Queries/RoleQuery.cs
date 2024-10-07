using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class RoleQuery
    {
        private readonly AppDbContext _context;
        // Inject AppDbContext into the query class
        public RoleQuery(AppDbContext context)
        {
            _context = context;
        }

        // Resolver to get a list of roles
        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // Resolver to get a role by ID
        public async Task<Role?> GetRoleById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
    }
}
