using API.Veiculos;

namespace API 
{
    public class QueryObjectType : ObjectType<VeiculosQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<VeiculosQueries> descriptor)
        {
            descriptor.Field(_ => _.TestProtect()).Name("test_protect").Type<StringType>().Authorize();
        }
    }
}