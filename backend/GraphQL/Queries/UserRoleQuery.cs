using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class UserRoleQuery
    {
        private readonly AppDbContext _context;

        // Inject AppDbContext into the query class
        public UserRoleQuery(AppDbContext context)
        {
            _context = context;
        }

        // Resolver to get all UserRoles
        public async Task<IEnumerable<UserRole>> GetAllUserRoles()
        {
            // Ensure that the result is a non-nullable collection, even if empty
            var userRoles = await _context.UserRoles.ToListAsync();
            return userRoles ?? Enumerable.Empty<UserRole>(); // Use empty collection if null
        }

        // Resolver to get a UserRole by ID
        public async Task<UserRole?> GetUserRoleById(int id)
        {
            return await _context.UserRoles.FindAsync(id);
        }
    }
}
