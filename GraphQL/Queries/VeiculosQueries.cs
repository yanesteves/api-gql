using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using System.Security.Claims;

namespace API.Veiculos 
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class VeiculosQueries
    {
        // public GetVeiculo(int id, [Service] VeiculoRepository repository) => repository.GetVeiculos(id);
        public IEnumerable<IVeiculo> GetVeiculos([Service] IVeiculoRepository repository) => repository.GetVeiculos();

        [GraphQLName("get_veiculo")]
        public Veiculo GetVeiculo(int? id) {
            var veiculo = new Veiculo(1, "Nome", "Dono", "Cor", 12120);
            return veiculo;
        }

        [GraphQLName("get_dono")]
        public Dono GetDono() {
            var dono = new Dono("Yan");
            return dono;
        }
            
        public string GetMe(ClaimsPrincipal claimsPrincipal) {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }

    public class Dono {
        public Dono(string nome) {
            Nome = nome;        
        }

        public string Nome {get;}
    }
}