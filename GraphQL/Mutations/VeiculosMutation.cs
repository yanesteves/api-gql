using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using HotChocolate.Subscriptions;
using HotChocolate.AspNetCore.Authorization;
using API.GraphQL.Models;
namespace API.Veiculos
{    
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class VeiculosMutation
    {
        public async Task<Veiculo> CreateVeiculo(
            Veiculo input, [Service] IVeiculoRepository repository,            
            [Service]ITopicEventSender eventSender)
        {
            repository.AddVeiculo(input);
            
            var veiculoModel = new VeiculoViewModel(input);
            // Topico , Mensagem
            // await eventSender.SendAsync(veiculoModel.Tipo, veiculoModel);
            await eventSender.SendAsync(nameof(VeiculosSubscription.VeiculoAdicionado), veiculoModel).ConfigureAwait(false);
            
            return input;
        }
    }
}