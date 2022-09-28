namespace API.Veiculos 
{
    [InterfaceType]
    public interface IVeiculo 
    {
        int Id {get;}
        string Nome {get;}
        string Dono {get;}
        string Cor {get;}
        float Preco {get;}
    }
}