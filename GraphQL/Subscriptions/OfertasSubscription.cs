using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
namespace API.Ofertas
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class OfertasSubscription
    {
        [Subscribe]
        public Oferta OfertaLancada([EventMessage]Oferta message) => message;
    }
}