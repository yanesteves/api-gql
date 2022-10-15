using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.AspNetCore.Subscriptions.Messages;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace API.GraphQL.Middlewares
{

    public static class ValidateJWT
    {
        public static bool ValidateToken(string authToken)
        {
            var key = "MySecuredKey12345678910MySecuredKey12345678910";
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidIssuer = "localhost:7064",
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = "API",
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key)
            ),
            };

            SecurityToken validatedToken;
            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
    public class SubscriptionAuthMiddleware : ISocketSessionInterceptor
    {
        public async ValueTask OnCloseAsync(ISocketConnection connection, CancellationToken cancellationToken) { }
        public async ValueTask OnRequestAsync(ISocketConnection connection, IQueryRequestBuilder requestBuilder, CancellationToken cancellationToken) { }

        /* We don't need the above two methods, just this one */
        public async ValueTask<ConnectionStatus> OnConnectAsync(ISocketConnection connection, InitializeConnectionMessage message, CancellationToken cancellationToken)
        {
            try
            {
                // Nas subscriptions (websocket), o campo payload pode receber o que seria os cabeçalhos nos métodos http/https.
                // Com isso, capturo a propriedade Authorization e informo ser uma string, depois verifico se possui o Bearer antecedendo o token.
                // E faço a validação do token em outra função.
                var jwtHeader = message.Payload["Authorization"] as string;

                if (string.IsNullOrEmpty(jwtHeader) || !jwtHeader.StartsWith("Bearer "))
                    return ConnectionStatus.Reject("Unauthorized");

                var token = jwtHeader.Replace("Bearer ", "");
                
                var response = ValidateJWT.ValidateToken(token);
                
                if (!response) {
                    return ConnectionStatus.Reject("Sem autorização para se conectar ao websocket.");
                }

                // Adc o token ao HttpContext
                connection.HttpContext.Request.Headers.Authorization = jwtHeader;

                // Aceito a conexão websocket
                return ConnectionStatus.Accept();
            }
            catch (Exception ex)
            {
                return ConnectionStatus.Reject("Sem autorização para se conectar ao websocket.");
            }
        }
    }
}