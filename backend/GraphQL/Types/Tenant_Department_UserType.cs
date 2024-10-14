using backend.Models;

namespace backend.GraphQL.Types
{
    public class Tenant_Department_UserType : ObjectType<Tenant_Department_User>
    {
        protected override void Configure(IObjectTypeDescriptor<Tenant_Department_User> descriptor)
        {
            descriptor.Field(tdu => tdu.Id).Type<NonNullType<IntType>>();
            descriptor.Field(tdu => tdu.UserId).Type<NonNullType<IntType>>();
            descriptor.Field(tdu => tdu.TenantId).Type<NonNullType<IntType>>();
            descriptor.Field(tdu => tdu.DepartmentId).Type<NonNullType<IntType>>();
            descriptor.Field(tdu => tdu.User).Type<UserType>();
            descriptor.Field(tdu => tdu.Tenant).Type<TenantType>();
            descriptor.Field(tdu => tdu.Department).Type<DepartmentType>();
        }
    }

}
