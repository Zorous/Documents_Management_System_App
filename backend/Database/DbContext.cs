using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentAccess> DocumentAccesses { get; set; }
        public DbSet<Payment> Payments { get; set; }

        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    }
}
