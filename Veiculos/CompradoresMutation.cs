using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;

namespace API.Veiculos
{
    public class Comprador : IComprador {
        public Comprador(int id, string nome, string cpf, int idade) {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
        }

        public int Id {get;}
        public string Nome {get;}
        public string Cpf {get;}
        public int Idade {get;}
    }

    [InterfaceType]
    public interface IComprador {
        int Id {get;}
        string Nome {get;}
        string Cpf {get;}
        int Idade {get;}
    }

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class CompradoresMutation
    {
        public Comprador CreateComprador(
            Comprador input)
        {
            var comprador = new Comprador(input.Id, input.Nome, input.Cpf, input.Idade);
            // repository.AddComprador(comprador);

            return input;

        }
    }
}