using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Repositories;
using API.Veiculos;
using API.Mensagens;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    
    .AddSingleton<IVeiculoRepository, VeiculoRepository>()

    .AddGraphQLServer()

    // Queries
    .AddQueryType()
        .AddTypeExtension<VeiculosQueries>()

    // Mutations
    .AddMutationType()
        .AddTypeExtension<VeiculosMutation>()

    // Subscriptions
    .AddSubscriptionType()
        .AddTypeExtension<VeiculosSubscription>()

    .AddType<Veiculo>()
    .AddType<Comprador>()
    .AddType<Friend>()    

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
