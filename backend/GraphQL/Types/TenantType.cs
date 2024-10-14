using backend.Models;

namespace backend.GraphQL.Types
{
    public class TenantType : ObjectType<Tenant>
    {
        protected override void Configure(IObjectTypeDescriptor<Tenant> descriptor)
        {
            descriptor.Field(t => t.TenantId).Type<NonNullType<IntType>>();
            descriptor.Field(t => t.TenantName).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.Domain).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(t => t.Documents).Type<ListType<DocumentType>>();
            descriptor.Field(t => t.Payments).Type<ListType<PaymentType>>();
            descriptor.Field(t => t.Tenant_Department_Users).Type<ListType<Tenant_Department_UserType>>();
            descriptor.Field(t => t.Roles).Type<ListType<UserRoleType>>();
        }
    }

}
