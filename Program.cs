using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Repositories;
using API.Veiculos;
// using API.Mensagens;
using API.Ofertas;
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IVeiculoRepository, VeiculoRepository>()
    .AddSingleton<IOfertaRepository, OfertaRepository>()
    .AddGraphQLServer()

    // Queries
    .AddQueryType()
        .AddTypeExtension<VeiculosQueries>()
        .AddTypeExtension<OfertasQueries>()

    // Mutations
    .AddMutationType()
        .AddTypeExtension<VeiculosMutation>()
        .AddTypeExtension<OfertasMutation>()

    // Subscriptions
    .AddSubscriptionType()
        .AddTypeExtension<VeiculosSubscription>()
        .AddTypeExtension<OfertasSubscription>()

    .AddType<Veiculo>()
    .AddType<Oferta>()
    .AddType<Comprador>()
    // .AddType<Friend>()    

    .AddInMemorySubscriptions()
    .AddApolloTracing();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corsapp");

// app.MapGraphQL();

// Adicionando o "suporte" ao WebSockets em graphql
app.UseWebSockets()
    .UseRouting()
    .UseEndpoints(endpoint => endpoint.MapGraphQL());

app.Run();
