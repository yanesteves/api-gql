using API.Models;
using API.Auth;

namespace API.Repositories
{
    public interface IUsuarioRepository 
    {
        IEnumerable<User> GetUsers();

        void AddUser(User user);

        User GetUser(int id);

        User? AuthUser(LoginInput login);
    }
}