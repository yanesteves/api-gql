using System.Linq;
using API.Auth;
using API.Models;
using API.Veiculos;
using System.Security.Claims;
namespace API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private List<User> _users = new List<User>
        {
            new User{
                Id = 1,
                Nome = "Yan Esteves",
                Email = "yan.m.esteves@gmail.com",
                Password="123456",
                // Claims = new Claim[] { new Claim(ClaimTypes.Role, "superadmin") }
            },
            new User{
                Id = 2,
                Nome = "Marco",
                Email = "marco@gmail.com",
                Password = "abcdef",
                // Claims = new Claim[] { new Claim(ClaimTypes.Role, "user") }
            }
        };
        
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? AuthUser(LoginInput login)
        {
            var user = _users.Where(_ => _.Email.ToLower() == login.Email.ToLower() &&
                        _.Password == login.Password).FirstOrDefault();

            return user;
        }

        public User GetUser(int id)
        {
            return _users.Single(q => q.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users.Where(_ => _.Email.Contains(""));
        }
    }
}