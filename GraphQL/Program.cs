using GraphQL.Data;
using GraphQL.GraphQL;
using GraphQL.GraphQL.Commands;
using GraphQL.GraphQL.Platforms;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddPooledDbContextFactory<AppDBContext>(opt => opt.UseSqlServer(builder.Configuration["DefaultConnection"]));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<MutationTypes>()
    .AddSubscriptionType<Subscription>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddInMemorySubscriptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseWebSockets();

app.UseRouting();

app.MapGraphQL();

app.UseGraphQLVoyager("/graphql-voyager", new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql",
});
app.Run();
