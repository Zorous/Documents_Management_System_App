using backend.Models;
using System.Xml.Linq;

namespace backend.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(u => u.UserId).Type<NonNullType<IntType>>();
            descriptor.Field(u => u.UserName).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.Email).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.PasswordHash).Type<NonNullType<StringType>>();
            descriptor.Field(u => u.CreatedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(u => u.UserRoles).Type<ListType<UserRoleType>>();
            descriptor.Field(u => u.CreatedDocuments).Type<ListType<DocumentType>>();
            descriptor.Field(u => u.DocumentAccesses).Type<ListType<DocumentAccessType>>();
            descriptor.Field(u => u.Tenant_Department_Users).Type<ListType<Tenant_Department_UserType>>();
        }
    }

}
