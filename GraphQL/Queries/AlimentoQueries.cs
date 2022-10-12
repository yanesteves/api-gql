using API.Context;
using API.Repositories;
using HotChocolate.AspNetCore.Authorization;
using API.Models;
using API.GraphQL.Outputs;

namespace API.GraphQL.Query
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class AlimentoQuery
    {
        public List<Alimento> GetAlimento([Service] DEVInCarContext context, int? id)
        {
            return context.Alimentos.ToList();            
        }

        public List<AlimentoViewModel> GetAlimentoModel([Service] DEVInCarContext context, int? id)
        {
            return context.Alimentos.Select(c => new AlimentoViewModel() {
                Id = c.Id,
                Nome = c.Nome,
                TipoID = c.TipoID,
                TipoAlimento = context.TipoAlimentos.Where(q => q.Id == c.TipoID).Select(q => q.Nome).SingleOrDefault()
            }).ToList();            
        }
    }
}