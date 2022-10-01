using System.Linq;
using API.Veiculos;

namespace API.Repositories 
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private Dictionary<int, IVeiculo> _veiculos;

        public VeiculoRepository() 
        {
            _veiculos = CreateVeiculos().ToDictionary(t => t.Id);
        }

        public IEnumerable<IVeiculo> GetVeiculos()
        {
            IEnumerable<IVeiculo> filteredVeiculos = _veiculos.Values.Where(t => t.Nome.Contains(""));
            return filteredVeiculos;
        }

        
        public void AddVeiculo(Veiculo veiculo)
        {
            List<IVeiculo> veiculos = CreateVeiculos().ToList();
            veiculos.Add(veiculo);
            _veiculos = veiculos.ToDictionary(t => t.Id);
        }

        private static IEnumerable<IVeiculo> CreateVeiculos() 
        {
            yield return new Veiculo(1, "Citroen", "Jorge", "Cinza", 124000);
            yield return new Veiculo(2, "BMW", "Ricardo", "Cinza", 134000);
            yield return new Veiculo(3, "VW", "Jorge", "Branco", 134000);
            yield return new Veiculo(4, "Mercedes", "Vera", "Preto", 9000);
        }

    }
}