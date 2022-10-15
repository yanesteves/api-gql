using API.GraphQL.Outputs;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
namespace API.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class VeiculosSubscription
    {
        [Subscribe]
        // Altero o tipo de retorno para não conflitar o Authorize das propriedades de veículo.
        // Para a subscription, considerarei que os usuários ativos como autenticados, pela configuração definida no middleware de autenticação.
        public VeiculoViewModel VeiculoAdicionado([EventMessage] VeiculoViewModel message) => message;

        [Subscribe]
        public Veiculo TipoVeiculoAdicionado([Topic] TipoVeiculo tipo, [EventMessage] Veiculo message) => message;
    }
}