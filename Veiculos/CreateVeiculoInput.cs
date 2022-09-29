namespace API.Veiculos
{
    public class CreateVeiculoInput
    {
        public CreateVeiculoInput(Veiculo veiculo)
        {
            Veiculo = veiculo;
        }

        public Veiculo Veiculo { get; }
    }
}