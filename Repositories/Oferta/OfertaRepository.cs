using System.Linq;
using API.Ofertas;
using System.Linq;

namespace API.Repositories 
{
    public class OfertaRepository : IOfertaRepository
    {
        // private Dictionary<int, IOferta> _ofertas;
        private List<IOferta> _ofertas = new List<IOferta>();

        public OfertaRepository() 
        {
            // _veiculos = CreateVeiculos().ToDictionary(t => t.Id);
        }

        public IEnumerable<IOferta> GetOfertas()
        {
            IEnumerable<IOferta> filtered = _ofertas.Where(t => t.Usuario.Contains(""));
            return filtered;
        }
        
        public Oferta AddOferta(Oferta oferta)
        {
            _ofertas.Add(oferta);            
            var maior = (Oferta)_ofertas.OrderByDescending(i=>i.Valor).First();
            return maior;

            // return _ofertas.Max(q => q.Valor);
        }
        public IEnumerable<IOferta> GetOfertasByUser(string user)
        {
            var filtered = (from ofertas in _ofertas where ofertas.Usuario == user select ofertas);

            return filtered;
        }
    }
}