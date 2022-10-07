using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Auth;
using API.Models;
using API.Ofertas;
using API.Repositories;
using API.Veiculos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {    
            // GraphQL Server
            services.AddGraphQLServer()
            // Queries
            .AddQueryType<QueryObjectType>()
            .AddAuthorization()
                // .AddTypeExtension<VeiculosQueries>()
                // .AddTypeExtension<QueryObjectType>()
                // .AddTypeExtension<OfertasQueries>()
                // .AddTypeExtension<TestQuery>()

            // Mutations
            .AddMutationType()
                .AddTypeExtension<VeiculosMutation>()
                .AddTypeExtension<OfertasMutation>()
                .AddTypeExtension<AuthMutation>()

            // Subscriptions
            .AddSubscriptionType()
                .AddTypeExtension<VeiculosSubscription>()
                .AddTypeExtension<OfertasSubscription>()

            .AddType<Veiculo>()
            .AddType<Oferta>()
            .AddType<Comprador>()
            .AddInMemorySubscriptions()
            .AddApolloTracing();
            
            // Carregando o repository
            services
                .AddSingleton<IVeiculoRepository, VeiculoRepository>()
                .AddSingleton<IOfertaRepository, OfertaRepository>();

            // Configuração do cors
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration.GetSection("TokenSettings").GetValue<string>("Issuer"),
                    ValidAudience = Configuration.GetSection("TokenSettings").GetValue<string>("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("TokenSettings").GetValue<string>("Key"))),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // configuração da autenticação/autorização
            app.UseAuthentication();
            app.UseAuthorization();
            
            // configuração do graphql endpoint e websockets
            app.UseWebSockets()      
            .UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
