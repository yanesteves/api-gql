using Api.DEV;

var builder = WebApplication.CreateBuilder(args);
// .AddSingleton<InterfaceRepository, Repository>()

builder.Services
    .AddGraphQLServer()
        .AddTypeExtension<>()
    
    .AddType<Developer>()

    .AddApolloTracing();
    // .AddQueryType<Query>()g;


var app = builder.Build();

app.MapGraphQL();
app.Run();