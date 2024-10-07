using backend.Database;
using backend.Models;
using System;
using System.Linq;

public class DatabaseSeeder
{
    private readonly AppDbContext _context;

    public DatabaseSeeder(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        // Seed Permissions
        if (!_context.Permissions.Any())
        {
            _context.Permissions.AddRange(
                new Permission { PermissionName = "Read", CreatedAt = DateTime.UtcNow },
                new Permission { PermissionName = "Write", CreatedAt = DateTime.UtcNow },
                new Permission { PermissionName = "Update", CreatedAt = DateTime.UtcNow },
                new Permission { PermissionName = "Delete", CreatedAt = DateTime.UtcNow },
                new Permission { PermissionName = "Admin", CreatedAt = DateTime.UtcNow }
            );

            _context.SaveChanges();
        }

        // Seed Roles
        if (!_context.Roles.Any())
        {
            _context.Roles.AddRange(
                new Role { RoleName = "User", CreatedAt = DateTime.UtcNow },
                new Role { RoleName = "Admin", CreatedAt = DateTime.UtcNow },
                new Role { RoleName = "Manager", CreatedAt = DateTime.UtcNow },
                new Role { RoleName = "Developer", CreatedAt = DateTime.UtcNow },
                new Role { RoleName = "Support", CreatedAt = DateTime.UtcNow }
            );

            _context.SaveChanges();
        }

        // Seed Tenants
        if (!_context.Tenants.Any())
        {
            _context.Tenants.AddRange(
                new Tenant { TenantName = "Tenant A", Domain = "tenantA.com", CreatedAt = DateTime.UtcNow },
                new Tenant { TenantName = "Tenant B", Domain = "tenantB.com", CreatedAt = DateTime.UtcNow },
                new Tenant { TenantName = "Tenant C", Domain = "tenantC.com", CreatedAt = DateTime.UtcNow },
                new Tenant { TenantName = "Tenant D", Domain = "tenantD.com", CreatedAt = DateTime.UtcNow },
                new Tenant { TenantName = "Tenant E", Domain = "tenantE.com", CreatedAt = DateTime.UtcNow }
            );

            _context.SaveChanges();
        }
    }
}
