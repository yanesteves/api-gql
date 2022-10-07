using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using API.Models;

namespace API.Users 
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class UsersQueries
    {        
        // [GraphQLName("...")]
        public IEnumerable<User> GetUsers([Service] IUsuarioRepository repository) => repository.GetUsers();

        public User GetUser([Service] IUsuarioRepository repository, int userID) => repository.GetUser(userID);
            
    }
}