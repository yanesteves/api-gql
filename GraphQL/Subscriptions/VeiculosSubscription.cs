using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
namespace API.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class VeiculosSubscription
    {
        [Subscribe]
        public Veiculo VeiculoAdicionado([EventMessage]Veiculo message) => message;

        [Subscribe]
        public Veiculo TipoVeiculoAdicionado([Topic]TipoVeiculo tipo, [EventMessage]Veiculo message) => message;
    }
}