using backend.Models;

namespace backend.GraphQL.Types
{
    public class DocumentAccessType : ObjectType<DocumentAccess>
    {
        protected override void Configure(IObjectTypeDescriptor<DocumentAccess> descriptor)
        {
            descriptor.Field(da => da.DocumentAccessId).Type<NonNullType<IntType>>();
            descriptor.Field(da => da.DocumentId).Type<NonNullType<IntType>>();
            descriptor.Field(da => da.UserId).Type<NonNullType<IntType>>();
            descriptor.Field(da => da.AccessLevel).Type<NonNullType<StringType>>();
            descriptor.Field(da => da.IsActive).Type<NonNullType<BooleanType>>();
            descriptor.Field(da => da.GrantedAt).Type<NonNullType<DateTimeType>>();
            descriptor.Field(da => da.Document).Type<DocumentType>();
            descriptor.Field(da => da.User).Type<UserType>();
        }
    }

}
