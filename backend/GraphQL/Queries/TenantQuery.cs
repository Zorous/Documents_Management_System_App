using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.GraphQL.Queries
{
    public class TenantQuery
    {
        private readonly AppDbContext _dbContext;

        // Inject AppDbContext via constructor
        public TenantQuery(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Resolver to get a tenant by ID
        public async Task<Tenant?> GetTenantById(int id)
        {
            return await _dbContext.Tenants.FindAsync(id);
        }

        // Resolver to get all tenants
        public async Task<IEnumerable<Tenant>> GetTenants()
        {
            return await _dbContext.Tenants.ToListAsync();
        }
    }
}
