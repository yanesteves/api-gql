using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using HotChocolate.Subscriptions;
namespace API.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class VeiculosMutation
    {
        public Veiculo CreateVeiculo(
            Veiculo input, [Service] IVeiculoRepository repository,
            [Service]ITopicEventSender eventSender)
        {
            var veiculo = new Veiculo(input.Id, input.Nome, 
            input.Dono, input.Cor, input.Preco, input.Tipo);

            repository.AddVeiculo(veiculo);
            
            // O tópico que a mensagem pertence, dado a ser enviado
            eventSender.SendAsync(veiculo.Tipo, veiculo).ConfigureAwait(false);
            eventSender.SendAsync(veiculo.Nome, veiculo).ConfigureAwait(false);            
            
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