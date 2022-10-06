using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using System.Security.Claims;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;

namespace API.Veiculos 
{    
    [Authorize]
    [ExtendObjectType(OperationTypeNames.Query)]    
    public class VeiculosQueries //: ObjectType<VeiculosQueries>
    {
        // protected override void Configure(IObjectTypeDescriptor<VeiculosQueries> descriptor)
        // {            
        //     // descriptor.Field(_ => _.TestProtect()).Name("TesteProtect").Type<StringType>().Authorize();
        // }
        // public GetVeiculo(int id, [Service] VeiculoRepository repository) => repository.GetVeiculos(id);
        // public IEnumerable<IVeiculo> GetVeiculos([Service] IVeiculoRepository repository) => repository.GetVeiculos();

        // [GraphQLName("get_veiculo")]
        // public Veiculo GetVeiculo(int? id) {
        //     var veiculo = new Veiculo(1, "Nome", "Dono", "Cor", 12120);
        //     return veiculo;
        // }

        // [GraphQLName("get_dono")]
        // // [Authorize]
        // public Dono GetDono() {            
        //     var dono = new Dono("Yan");
        //     return dono;
        // }
                
        public string TestProtect() {
            return "Success";
        }       
        // public string GetMe(ClaimsPrincipal claimsPrincipal) {
        //     var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        //     return userId;
        // }
    }    
    public class Dono {
        public Dono(string nome) {
            Nome = nome;        
        }

        public string Nome {get;}
    }
}