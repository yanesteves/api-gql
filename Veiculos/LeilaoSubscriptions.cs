using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;

namespace API.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class LeilaoSubscription
    {
        [Subscribe]
        public Veiculo OnLeilao([EventMessage]Veiculo message) => message;
    }
}