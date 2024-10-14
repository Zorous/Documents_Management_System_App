using HotChocolate;
using backend.Models;
using backend.Database;

namespace backend.GraphQL.Mutations
{
    public class TenantMutations
    {
        public async Task<Tenant> CreateTenantAsync([Service] AppDbContext context, Tenant tenant)
        {
            context.Tenants.Add(tenant);
            await context.SaveChangesAsync();
            return tenant;
        }

        public async Task<Tenant> UpdateTenantAsync([Service] AppDbContext context, Tenant tenant)
        {
            context.Tenants.Update(tenant);
            await context.SaveChangesAsync();
            return tenant;
        }

        public async Task<bool> DeleteTenantAsync([Service] AppDbContext context, int tenantId)
        {
            var tenant = await context.Tenants.FindAsync(tenantId);
            if (tenant == null) return false;

            context.Tenants.Remove(tenant);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
