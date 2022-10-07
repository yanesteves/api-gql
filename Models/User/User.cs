using HotChocolate.AspNetCore.Authorization;
// using System.Security.Claims;
namespace API.Models
{
     public class User
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        
        [Authorize]
        public string? Email { get; set; }
        
        [Authorize] 
        public string? Password { get; set; }        
        // [Authorize(Roles = new[] { "Administrator" })]
        
        // [Authorize]
        // public Claim[]? Claims { get; set; }        
    }

}