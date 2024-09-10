using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Security;
using backend.Models;
using Microsoft.EntityFrameworkCore;

//To avoid ambiguity complex : 'Document' is an ambiguous reference between 'backend.Models.Document' and 'System.Reflection.Metadata.Document'
using myDoucment = backend.Models.Document;


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
        public DbSet<myDoucment> Documents { get; set; }
        public DbSet<DocumentAccess> DocumentAccesses { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=Documents_Management_System_App;Username=postgres;Password=123456");
    }




}