using backend.Database;
using backend.GraphQL.QueryType;
using backend.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Load configuration from appsettings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add DbContext with PostgreSQL configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the DatabaseSeeder service
builder.Services.AddScoped<DatabaseSeeder>();

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure GraphQL
builder.Services.AddGraphQLServer()
    .AddQueryType<Queries>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

builder.Logging.AddConsole(); // For detailed logs

var app = builder.Build();

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    dbContext.Database.Migrate(); // Apply migrations
    seeder.Seed(); // Seed the database
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseRouting();

// GraphQL Integration
app.MapGraphQL();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
