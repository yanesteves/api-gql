using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;

namespace API.Veiculos
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class VeiculosMutation
    {
        public Veiculo CreateVeiculo(
            Veiculo input,
            [Service] IVeiculoRepository repository)
        {
            var veiculo = new Veiculo(input.Id, input.Nome, input.Dono, input.Cor, input.Preco);
            repository.AddVeiculo(veiculo);

            return input;

        }
    }
}