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
        private List<User> Users = new List<User>
        {
            new User{
                Id = 1,
                Nome = "Yan Esteves",
                Email = "yan.m.esteves@gmail.com",
                Password="123456"
            },
            new User{
                Id = 2,
                Nome = "Marco",
                Email = "marco@gmail.com",
                Password = "abcdef"
            }
        };

        public string UserLogin([Service] IOptions<TokenSettings> tokenSettings, LoginInput login)
        {
            var currentUser = Users.Where(_ => _.Email.ToLower() == login.Email.ToLower() &&
                        _.Password == login.Password).FirstOrDefault();
            if (currentUser != null)
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    issuer: tokenSettings.Value.Issuer,
                    audience: tokenSettings.Value.Audience,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);

            }
            return "";
        }
    }
}