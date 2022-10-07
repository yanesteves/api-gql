using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using API.Repositories;
using HotChocolate.Subscriptions;
using API.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
// using System.Security.Claims;

namespace API.Auth
{
    public class LoginInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AuthMutation
    {       
        public string UserLogin([Service] IOptions<TokenSettings> tokenSettings, 
        [Service] IUsuarioRepository repository, 
        LoginInput login)
        {
            var currentUser = repository.AuthUser(login);
            if (currentUser != null)
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    issuer: tokenSettings.Value.Issuer,
                    audience: tokenSettings.Value.Audience,                    
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddMinutes(20)
                    // claims: ...
                );

                string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return token;

            }
            return string.Empty;
        }
    }
}