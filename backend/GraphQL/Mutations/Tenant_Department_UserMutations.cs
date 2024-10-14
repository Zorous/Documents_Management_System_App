using HotChocolate;
using backend.Models;
using backend.Database;

namespace backend.GraphQL.Mutations
{
    public class Tenant_Department_UserMutations
    {
        public async Task<Tenant_Department_User> CreateTenant_Department_UserAsync([Service] AppDbContext context, Tenant_Department_User tenant_Department_User)
        {
            context.Tenant_Department_Users.Add(tenant_Department_User);
            await context.SaveChangesAsync();
            return tenant_Department_User;
        }

        public async Task<Tenant_Department_User> UpdateTenant_Department_UserAsync([Service] AppDbContext context, Tenant_Department_User tenant_Department_User)
        {
            context.Tenant_Department_Users.Update(tenant_Department_User);
            await context.SaveChangesAsync();
            return tenant_Department_User;
        }

        public async Task<bool> DeleteTenant_Department_UserAsync([Service] AppDbContext context, int tenant_Department_UserId)
        {
            var tenant_Department_User = await context.Tenant_Department_Users.FindAsync(tenant_Department_UserId);
            if (tenant_Department_User == null) return false;

            context.Tenant_Department_Users.Remove(tenant_Department_User);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
