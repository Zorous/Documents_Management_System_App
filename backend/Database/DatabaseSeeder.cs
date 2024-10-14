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

        // Seed Departments
        if (!_context.Departments.Any())
        {
            _context.Departments.AddRange(
                new Department { DepartmentName = "HR", CreatedAt = DateTime.UtcNow },
                new Department { DepartmentName = "Finance", CreatedAt = DateTime.UtcNow },
                new Department { DepartmentName = "IT", CreatedAt = DateTime.UtcNow },
                new Department { DepartmentName = "Marketing", CreatedAt = DateTime.UtcNow },
                new Department { DepartmentName = "Sales", CreatedAt = DateTime.UtcNow }
            );

            _context.SaveChanges();
        }

        // Seed Users
        if (!_context.Users.Any())
        {
            _context.Users.AddRange(
                new User { UserName = "User1", Email = "user1@tenantA.com", PasswordHash = "hashedpassword1", ProfilePicture = null, CreatedAt = DateTime.UtcNow },
                new User { UserName = "User2", Email = "user2@tenantB.com", PasswordHash = "hashedpassword2", ProfilePicture = null, CreatedAt = DateTime.UtcNow },
                new User { UserName = "User3", Email = "user3@tenantC.com", PasswordHash = "hashedpassword3", ProfilePicture = null, CreatedAt = DateTime.UtcNow }
            );

            _context.SaveChanges();
        }

        // Seed Tenant_Department_User relationships
        if (!_context.Tenant_Department_Users.Any())
        {
            var users = _context.Users.ToList();
            var tenants = _context.Tenants.ToList();
            var departments = _context.Departments.ToList();

            // Add relationships
            if (users.Any() && tenants.Any() && departments.Any())
            {
                _context.Tenant_Department_Users.AddRange(
                    new Tenant_Department_User { UserId = users[0].UserId, TenantId = tenants[0].TenantId, DepartmentId = departments[0].DepartmentId }
                );

                _context.SaveChanges();
            }
        }
    }
}
