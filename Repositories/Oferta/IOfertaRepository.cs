using API.Ofertas;

namespace API.Repositories
{
    public interface IOfertaRepository 
    {
        Oferta AddOferta(Oferta oferta);
        IEnumerable<IOferta> GetOfertas();
    }
}