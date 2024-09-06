using GraphQL.Types;
using backend_dotNET.Models; // Ensure this namespace matches where your models are defined
using Microsoft.EntityFrameworkCore;
using GraphQL;

namespace backend_dotNET.GraphQL
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(DbContext dbContext)
        {
            Field<TenantType>(
                "createTenant",
                arguments: new QueryArguments(new QueryArgument<TenantInputType> { Name = "tenant" }),
                resolve: context =>
                {
                    var tenant = context.GetArgument<Tenant>("tenant");
                    dbContext.Tenants.Add(tenant);
                    dbContext.SaveChanges();
                    return tenant;
                }
            );

            // Add mutations for other entities
        }
    }
}
