using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;

namespace API.Ofertas 
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class OfertasQueries
    {        
        public IEnumerable<IOferta> GetOfertas([Service] IOfertaRepository repository) => repository.GetOfertas();
            
    }
}