using API.Veiculos;

namespace API.Repositories
{
    public interface IVeiculoRepository 
    {
        // IVeiculo GetVeiculo(int id);
        IEnumerable<IVeiculo> GetVeiculos();
    }
}