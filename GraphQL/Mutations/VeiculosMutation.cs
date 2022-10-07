using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using HotChocolate.Subscriptions;
using HotChocolate.AspNetCore.Authorization;

namespace API.Veiculos
{    
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class VeiculosMutation
    {
        public async Task<Veiculo> CreateVeiculo(
            Veiculo input, [Service] IVeiculoRepository repository,
            [Service]ITopicEventSender eventSender)
        {
            var veiculo = new Veiculo(input.Id, input.Nome, input.Dono, input.Cor, input.Preco, input.Tipo);
            repository.AddVeiculo(veiculo);
            
            // Topico , Mensagem
            await eventSender.SendAsync(veiculo.Tipo, veiculo);

            // await eventSender.SendAsync(nameof(VeiculosSubscription.VeiculoAdicionado), veiculo).ConfigureAwait(false);
            
            return input;
        }

        // public Veiculo CreateVeiculo(
        //     Veiculo input,
        //     [Service] IVeiculoRepository repository)
        // {
        //     var veiculo = new Veiculo(input.Id, input.Nome, input.Dono, input.Cor, input.Preco);
        //     repository.AddVeiculo(veiculo);

        //     return input;

        // }
    }
}