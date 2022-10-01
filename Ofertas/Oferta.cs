namespace API.Ofertas 
{
    public class Oferta : IOferta
    {
        public Oferta(string usuario, float valor) 
        {
            Usuario = usuario;
            Valor = valor;
        }

        public string Usuario {get;}
        public float Valor {get;}
    }
}