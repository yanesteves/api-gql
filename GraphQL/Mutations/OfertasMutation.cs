using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using HotChocolate.Subscriptions;

namespace API.Ofertas
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class OfertasMutation
    {
        public async Task<Oferta> CreateOferta (
            Oferta input, 
        [Service] IOfertaRepository repository,
        [Service]ITopicEventSender eventSender)
        {
            var oferta = new Oferta(input.Usuario, input.Valor);
            Oferta maiorOferta = repository.AddOferta(input);               
            await eventSender.SendAsync(nameof(OfertasSubscription.OfertaLancada), maiorOferta).ConfigureAwait(false);
            return oferta;
        }
    }
}