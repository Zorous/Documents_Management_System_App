using backend.Database;
using backend.Models;



namespace backend.GraphQL.Mutations
{
    public class UserMutations
{
    public async Task<User> CreateUserAsync(User input, [Service] AppDbContext dbContext)
    {
        dbContext.Users.Add(input);
        await dbContext.SaveChangesAsync();
        return input;
    }

    public async Task<User> UpdateUserAsync(int userId, User input, [Service] AppDbContext dbContext)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null) throw new Exception("User not found");

        user.UserName = input.UserName;
        user.ProfilePicture = input.ProfilePicture;
        user.Email = input.Email;
        user.PasswordHash = input.PasswordHash;
        user.CreatedAt = input.CreatedAt; // Depending on your logic, you might not want to update CreatedAt

        await dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteUserAsync(int userId, [Service] AppDbContext dbContext)
    {
        var user = await dbContext.Users.FindAsync(userId);
        if (user == null) throw new Exception("User not found");

        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
        return true;
    }
    }
}
