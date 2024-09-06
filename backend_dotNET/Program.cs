using Microsoft.EntityFrameworkCore;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using backend_dotNET.GraphQL;
using backend_dotNET.Models; // Ensure correct namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext with PostgreSQL connection string
builder.Services.AddDbContext<DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

// Register GraphQL services
builder.Services.AddScoped<Query>();
builder.Services.AddScoped<Mutation>();
builder.Services.AddScoped<ISchema, Schema>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<TenantType>()
    .AddType<UserType>()
    .AddType<RoleType>();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Use GraphQL Playground
app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
{
    GraphQLEndPoint = "/graphql"
});

// Configure GraphQL endpoint
app.MapGraphQL("/graphql");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
