namespace API.Veiculos 
{
    public class Veiculo : IVeiculo 
    {
        public Veiculo(int id, string nome, string dono, string cor, float preco) {
            Id = id;
            Nome = nome;
            Dono = dono;
            Cor = cor;
            Preco = preco;
        }

        public int Id {get;}
        public string Nome {get;}
        public string Dono {get;}
        public string Cor{get;}
        public float Preco {get;}
    }
}