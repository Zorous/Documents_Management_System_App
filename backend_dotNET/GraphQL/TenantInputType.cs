using GraphQL.Types;

namespace backend_dotNET.GraphQL
{
    public class TenantInputType : InputObjectGraphType
    {
        public TenantInputType()
        {
            Name = "TenantInput";
            Field<NonNullGraphType<StringGraphType>>("tenantName");
            Field<StringGraphType>("domain");
        }
    }
}
