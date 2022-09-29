using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Repositories;
using API.Veiculos;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IVeiculoRepository, VeiculoRepository>()
    .AddGraphQLServer()

    .AddQueryType()
        .AddTypeExtension<VeiculosQueries>()
    
    .AddMutationType()
        .AddTypeExtension<VeiculosMutation>()
        .AddTypeExtension<CompradoresMutation>()
    
    .AddType<Veiculo>()
    .AddType<IVeiculo>()
    .AddType<Comprador>()

    .AddApolloTracing();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors("corsapp");

app.MapGraphQL();

app.Run();
