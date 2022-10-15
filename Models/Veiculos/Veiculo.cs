using HotChocolate.AspNetCore.Authorization;

namespace API.Veiculos 
{
    public class Veiculo : IVeiculo 
    {
        public Veiculo(int id, string nome, string dono, string cor, float preco, TipoVeiculo tipo = TipoVeiculo.Carro) {
            Id = id;
            Nome = nome;
            Dono = dono;
            Cor = cor;
            Preco = preco;
            Tipo = tipo;
        }

        [Authorize]
        public int Id {get;}
        public string Nome {get;}
        public string Dono {get;}
        public string Cor{get;}
        public float Preco {get;}
        public TipoVeiculo Tipo{get;}
    }
}