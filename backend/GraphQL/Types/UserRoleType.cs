using backend.Models;

namespace backend.GraphQL.Types
{
    public class UserRoleType : ObjectType<UserRole>
    {
        protected override void Configure(IObjectTypeDescriptor<UserRole> descriptor)
        {
            descriptor.Field(ur => ur.UserRoleId).Type<NonNullType<IntType>>();
            descriptor.Field(ur => ur.UserId).Type<NonNullType<IntType>>();
            descriptor.Field(ur => ur.RoleId).Type<NonNullType<IntType>>();
            descriptor.Field(ur => ur.TenantId).Type<NonNullType<IntType>>();
            descriptor.Field(ur => ur.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(ur => ur.User).Type<UserType>();
            descriptor.Field(ur => ur.Role).Type<RoleType>();
            descriptor.Field(ur => ur.Tenant).Type<TenantType>();
        }
    }

}
