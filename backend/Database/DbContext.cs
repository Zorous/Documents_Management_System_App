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

        public DbSet<Department> Departments { get; set; }

        public DbSet<Tenant_Department_User> Tenant_Department_User { get; set; }


        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring the many-to-many relationship
            modelBuilder.Entity<Tenant_Department_User>()
                .HasKey(udt => udt.Id);

            modelBuilder.Entity<Tenant_Department_User>()
                .HasOne(udt => udt.User)
                .WithMany(u => u.Tenant_Department_Users) // Navigation property needs to be added to User
                .HasForeignKey(udt => udt.UserId);

            modelBuilder.Entity<Tenant_Department_User>()
                .HasOne(udt => udt.Tenant)
                .WithMany(t => t.Tenant_Department_Users) // Navigation property needs to be added to Tenant
                .HasForeignKey(udt => udt.TenantId);

            modelBuilder.Entity<Tenant_Department_User>()
                .HasOne(udt => udt.Department)
                .WithMany(d => d.Tenant_Department_Users) // Navigation property is already defined in Department
                .HasForeignKey(udt => udt.DepartmentId);
        }



    }




}


