using backend.Database;
using backend.Models;

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



    }
}
