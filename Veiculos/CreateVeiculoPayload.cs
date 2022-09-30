namespace API.Veiculos
{
    public class CreateVeiculoPayload 
    {
        public CreateVeiculoPayload(Veiculo veiculo) 
        {
            Veiculo = veiculo;
        }

        public Veiculo Veiculo {get;}
    }
}