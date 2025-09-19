using BackendTaskUsingGraphQL.Models;

namespace BackendTaskUsingGraphQL.GraphQL
{
    public class TaskType : ObjectType<TaskItem>
    {
        protected override void Configure(IObjectTypeDescriptor<TaskItem> descriptor)
        {
            descriptor.Field(t => t.Id).Type<NonNullType<UuidType>>();
            descriptor.Field(t => t.Title).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.Description).Type<StringType>();
            descriptor.Field(t => t.Status).Type<StringType>();
        }
    }
}
