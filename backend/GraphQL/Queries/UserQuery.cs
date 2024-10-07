using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.GraphQL.Queries
{
    public class UserQuery
    {
        private readonly AppDbContext _context;
        // Inject AppDbContext into the query class
        public UserQuery(AppDbContext context)
        {
            _context = context;
        }

        // Resolver to get a list of users
        public async Task<IEnumerable<User>> GetUsers()
        {
            // Ensure that the result is a non-nullable collection, even if empty
            var users = await _context.Users.ToListAsync();
            return users ?? Enumerable.Empty<User>(); // Use empty collection if null
        }

            // Resolver to get a user by ID
            public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

    }
}
