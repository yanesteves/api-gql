using HotChocolate.AspNetCore.Authorization;

namespace API.Models
{
     public class User
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        [Authorize] // estou informando ao hotchocolate que apenas usuários autorizados (com autenticação) poderão retornar este campo
        public string? Email { get; set; }
        [Authorize] // estou informando ao hotchocolate que apenas usuários autorizados (com autenticação) poderão retornar este campo
        public string? Password { get; set; }        
    }

}