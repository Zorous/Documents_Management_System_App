using backend.Database;
using backend.GraphQL.QueryType;
using backend.GraphQL.Queries;
using backend.GraphQL.Mutations;
using backend.GraphQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:8081", "http://127.0.0.1:8081") // Specify allowed origins
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()); // If you need to send credentials
});

// Load configuration from appsettings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add DbContext with PostgreSQL configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging()  // Enables detailed query logging
           .EnableDetailedErrors()         // Adds more error details
);

// Register the DatabaseSeeder service
builder.Services.AddScoped<DatabaseSeeder>();

// Register query services
builder.Services.AddScoped<UserQuery>();
builder.Services.AddScoped<DocumentQuery>();
builder.Services.AddScoped<RoleQuery>();
builder.Services.AddScoped<TenantQuery>();
builder.Services.AddScoped<DepartmentQuery>();
builder.Services.AddScoped<DocumentAccessQuery>();
builder.Services.AddScoped<PermissionQuery>();
builder.Services.AddScoped<PaymentQuery>();
builder.Services.AddScoped<RolePermissionQuery>();
builder.Services.AddScoped<UserRoleQuery>();
builder.Services.AddScoped<Tenant_Department_User_Query>();

// Register the main Queries class
builder.Services.AddScoped<Queries>();

// Register mutation services
builder.Services.AddScoped<UserMutations>();
builder.Services.AddScoped<DepartmentMutations>();
builder.Services.AddScoped<DocumentMutations>();
builder.Services.AddScoped<RoleMutations>();
builder.Services.AddScoped<TenantMutations>();
builder.Services.AddScoped<DocumentAccessMutations>();
builder.Services.AddScoped<UserRoleMutations>();
builder.Services.AddScoped<RolePermissionMutations>();
builder.Services.AddScoped<PaymentMutations>();
builder.Services.AddScoped<Tenant_Department_UserMutations>();
builder.Services.AddScoped<PermissionMutations>();

// Configure GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>() // Register the root query type
    .AddMutationType<Mutation>() // Register the Mutation class
    .AddType<Schemas>() // Register your AuthorType or any other object types
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);

// Add MVC services
builder.Services.AddControllersWithViews();

// Add console logging
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// Add HttpClient for proxy functionality
builder.Services.AddHttpClient();

var app = builder.Build();

// Ensure the database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();

    // Apply pending migrations and seed the database
    dbContext.Database.Migrate();
    seeder.Seed();
}

// Configure the HTTP request pipeline
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
app.UseCors("AllowSpecificOrigin");
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Map GraphQL endpoint
app.MapGraphQL();

// Map API Proxy endpoint
app.MapControllers();

// Set up the default route for MVC controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

