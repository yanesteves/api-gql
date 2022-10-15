using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using HotChocolate.Subscriptions;
using API.Context;
using API.Models;

namespace API.GraphQL.Mutation
{
    public class AlimentoInput
    {
        public string Nome { get; set; }
        public int TipoID { get; set; }
    }

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class CarsMutation
    {
        public async Task<bool> CreateAlimentoAsync([Service] DEVInCarContext context, AlimentoInput input)
        {
            try
            {

                context.Alimentos.Add(new Alimento() { Nome = input.Nome, TipoID = input.TipoID });
                await context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                throw new Exception("Não foi possível salvar o alimento.");
            }
        }
    }
}