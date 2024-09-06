using GraphQL.Types;
using backend_dotNET.Models; // Ensure this namespace matches where your models are defined
using Microsoft.EntityFrameworkCore;
using GraphQL;

namespace backend_dotNET.GraphQL
{
    public class Query : ObjectGraphType
    {
        public Query(DbContext dbContext)
        {
            Field<ListGraphType<TenantType>>(
                "tenants",
                resolve: context => dbContext.Tenants.ToList()
            );

            Field<TenantType>(
                "tenant",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => dbContext.Tenants.Find(context.GetArgument<int>("id"))
            );

            // Add fields for other entities
        }
    }
}
