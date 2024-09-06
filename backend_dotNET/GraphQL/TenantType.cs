using GraphQL.Types;
using backend_dotNET.Models; // Ensure this namespace matches where your models are defined

namespace backend_dotNET.GraphQL
{
    public class TenantType : ObjectGraphType<Tenant>
    {
        public TenantType()
        {
            Field(x => x.TenantId);
            Field(x => x.TenantName);
            Field(x => x.Domain);
            Field(x => x.CreatedAt);
        }
    }
}
