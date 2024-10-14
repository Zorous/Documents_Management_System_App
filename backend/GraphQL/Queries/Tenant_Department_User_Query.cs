using backend.Database;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.GraphQL.Queries
{
    public class Tenant_Department_User_Query
    {
        private readonly AppDbContext _context;

        // Inject AppDbContext into the query class
        public Tenant_Department_User_Query(AppDbContext context)
        {
            _context = context;
        }

        // Resolver to get all Tenant_Department_User records
        public async Task<IEnumerable<Tenant_Department_User>> GetAllTenantDepartmentUsers()
        {
            var result = await _context.Tenant_Department_Users
                .Include(x => x.Tenant)
                .Include(x => x.Department)
                .Include(x => x.User)
                .ToListAsync();

            return result;
        }

        // Resolver to get a Tenant_Department_User record by IDs
        public async Task<Tenant_Department_User?> GetTenantDepartmentUserByIds(int tenantId, int departmentId, int userId)
        {
            return await _context.Tenant_Department_Users
                .Include(x => x.Tenant)
                .Include(x => x.Department)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.TenantId == tenantId && x.DepartmentId == departmentId && x.UserId == userId);
        }
    }
}
