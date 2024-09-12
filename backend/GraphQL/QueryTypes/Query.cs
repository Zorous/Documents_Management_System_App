using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.GraphQL.QueryType;

public class Query
{
    //Connectivity test, we call this a resolver
    public string Instructions => "WUUHAHAHAHA";

    // Resolver to get a tenant by ID
    public async Task<Tenant> GetTenantById(int id, [Service] AppDbContext dbContext)
    {
        return await dbContext.Tenants.FindAsync(id);
    }

    // Resolver to get a list of users
    public async Task<IEnumerable<User>> GetUsers([Service] AppDbContext dbContext)
    {
        return await dbContext.Users.ToListAsync();
    }

    // Resolver to get a user by ID
    public async Task<User> GetUserById(int id, [Service] AppDbContext dbContext)
    {
        return await dbContext.Users.FindAsync(id);
    }

    // Resolver to get a list of documents
    public async Task<IEnumerable<Document>> GetDocuments([Service] AppDbContext dbContext)
    {
        return await dbContext.Documents.ToListAsync();
    }

    // Resolver to get a document by ID
    public async Task<Document> GetDocumentById(int id, [Service] AppDbContext dbContext)
    {
        return await dbContext.Documents.FindAsync(id);
    }

    // Resolver to get a list of roles
    public async Task<IEnumerable<Role>> GetRoles([Service] AppDbContext dbContext)
    {
        return await dbContext.Roles.ToListAsync();
    }

    // Resolver to get a role by ID
    public async Task<Role> GetRoleById(int id, [Service] AppDbContext dbContext)
    {
        return await dbContext.Roles.FindAsync(id);
    }

    // Resolver to get a list of permissions
    public async Task<IEnumerable<Permission>> GetPermissions([Service] AppDbContext dbContext)
    {
        return await dbContext.Permissions.ToListAsync();
    }

    // Resolver to get a permission by ID
    public async Task<Permission> GetPermissionById(int id, [Service] AppDbContext dbContext)
    {
        return await dbContext.Permissions.FindAsync(id);
    }

    // Resolver to get a list of document accesses
    public async Task<IEnumerable<DocumentAccess>> GetDocumentAccesses([Service] AppDbContext dbContext)
    {
        return await dbContext.DocumentAccesses.ToListAsync();
    }

    // Resolver to get document access by ID
    public async Task<DocumentAccess> GetDocumentAccessById(int id, [Service] AppDbContext dbContext)
    {
        return await dbContext.DocumentAccesses.FindAsync(id);
    }
}
