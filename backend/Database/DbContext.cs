using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Database
{
    public class AppDbContext : DbContext
    {



        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        // DbSet properties for models
        public DbSet<Department> Departments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentAccess> DocumentAccesses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Tenant_Department_User> Tenant_Department_Users { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department to Tenant_Department_User (One-to-Many)
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Tenant_Department_Users)
                .WithOne(tdu => tdu.Department)
                .HasForeignKey(tdu => tdu.DepartmentId);

            // Document to Tenant (One-to-Many)
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Tenant)
                .WithMany(t => t.Documents)
                .HasForeignKey(d => d.TenantId);

            // Document to User (Optional, CreatedBy nullable)
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Creator)
                .WithMany(u => u.CreatedDocuments)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull);

            // DocumentAccess to Document (One-to-Many)
            modelBuilder.Entity<DocumentAccess>()
                .HasOne(da => da.Document)
                .WithMany(d => d.DocumentAccesses)
                .HasForeignKey(da => da.DocumentId);

            // DocumentAccess to User (One-to-Many)
            modelBuilder.Entity<DocumentAccess>()
                .HasOne(da => da.User)
                .WithMany(u => u.DocumentAccesses)
                .HasForeignKey(da => da.UserId);

            // Payment to Tenant (One-to-Many)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Tenant)
                .WithMany(t => t.Payments)
                .HasForeignKey(p => p.TenantId);

            // RolePermission to Role (One-to-Many)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            // RolePermission to Permission (One-to-Many)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            // Tenant to Tenant_Department_User (One-to-Many)
            modelBuilder.Entity<Tenant>()
                .HasMany(t => t.Tenant_Department_Users)
                .WithOne(tdu => tdu.Tenant)
                .HasForeignKey(tdu => tdu.TenantId);

            // Tenant to UserRole (One-to-Many)
            modelBuilder.Entity<Tenant>()
                .HasMany(t => t.Roles)
                .WithOne(ur => ur.Tenant)
                .HasForeignKey(ur => ur.TenantId);

            // Tenant_Department_User to User (One-to-Many)
            modelBuilder.Entity<Tenant_Department_User>()
                .HasOne(tdu => tdu.User)
                .WithMany(u => u.Tenant_Department_Users)
                .HasForeignKey(tdu => tdu.UserId);

            // UserRole to User (One-to-Many)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            // UserRole to Role (One-to-Many)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }



}


