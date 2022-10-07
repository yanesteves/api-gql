using API.Repositories;
using System.Security.Claims;
using HotChocolate.AspNetCore.Authorization;

namespace API.Veiculos 
{    
    [ExtendObjectType(OperationTypeNames.Query)]    
    public class VeiculosQueries
    {
        public IVeiculo GetVeiculo(int id, [Service] VeiculoRepository repository) => repository.GetVeiculo(id);
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

        [Authorize] // Será cobrada autenticação para visualizar essa query      
        public string TestProtect() => "Sucesso";
        
        [Authorize] // Será cobrada autenticação para visualizar essa query     
        public string TestSuperProtect() => "Sucesso";
    }    
    public class Dono {
        public Dono(string nome) {
            Nome = nome;        
        }

        public string Nome {get;}
    }
}