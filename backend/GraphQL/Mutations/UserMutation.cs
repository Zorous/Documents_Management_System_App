using backend.Database;
using backend.Models;

namespace backend.GraphQL.Mutations
{
    public class UserMutation
    {
        private readonly AppDbContext _context;

        public UserMutation(AppDbContext context)
        {
            _context = context;
        }

        // Create User Mutation
        public async Task<User> CreateUser(CreateUserInput input)
        {
            var user = new User
            {
                TenantId = input.TenantId,
                UserName = input.UserName,
                Email = input.Email,
                PasswordHash = input.PasswordHash,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Update User Mutation
        public async Task<User?> UpdateUser(int id, UpdateUserInput input)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.UserName = input.UserName ?? user.UserName;
            user.Email = input.Email ?? user.Email;
            user.ProfilePicture = input.ProfilePicture ?? user.ProfilePicture;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Delete User Mutation
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    // Input Types
    public class CreateUserInput
    {
        public int TenantId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

    public class UpdateUserInput
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? ProfilePicture { get; set; }
    }

}
