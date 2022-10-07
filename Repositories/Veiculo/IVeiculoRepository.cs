using API.Veiculos;

namespace API.Repositories
{
    public interface IVeiculoRepository 
    {
        // IVeiculo GetVeiculo(int id);
        IEnumerable<IVeiculo> GetVeiculos();

        void AddVeiculo(Veiculo veiculo);

        IVeiculo GetVeiculo(int id);
    }
}