using API.Veiculos;

namespace API.GraphQL.Models
{
    public class VeiculoViewModel : IVeiculo
    {
        public VeiculoViewModel(Veiculo veiculo)
        {
            Id = veiculo.Id;
            Nome = veiculo.Nome;
            Dono = veiculo.Dono;
            Cor = veiculo.Cor;
            Preco = veiculo.Preco;
            Tipo = veiculo.Tipo;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Dono { get; set; }

        public string Cor { get; set; }

        public float Preco { get; set; }

        public TipoVeiculo Tipo { get; set; }
    }
}