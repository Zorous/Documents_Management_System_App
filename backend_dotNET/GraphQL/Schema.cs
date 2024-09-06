using GraphQL;
using GraphQL.Types;

namespace backend_dotNET.GraphQL
{
    public class Schema : global::GraphQL.Types.Schema
    {
        public Schema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<Query>();
            Mutation = provider.GetRequiredService<Mutation>();
        }
    }
}
