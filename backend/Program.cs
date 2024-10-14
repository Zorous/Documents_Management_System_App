using backend.Database;
using backend.GraphQL.QueryType;
using backend.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using HotChocolate.AspNetCore;
using backend.GraphQL.Mutations;
using HotChocolate;
using backend.GraphQL;

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

// Register query services
builder.Services.AddScoped<UserQuery>();
builder.Services.AddScoped<DocumentQuery>();
builder.Services.AddScoped<RoleQuery>();
builder.Services.AddScoped<TenantQuery>();          // Add TenantQuery
builder.Services.AddScoped<DepartmentQuery>();      // Add DepartmentQuery
builder.Services.AddScoped<DocumentAccessQuery>();  // Add DocumentAccessQuery
builder.Services.AddScoped<PermissionQuery>();      // Add PermissionQuery
builder.Services.AddScoped<PaymentQuery>();         // Add PaymentQuery
builder.Services.AddScoped<RolePermissionQuery>();  // Add RolePermissionQuery
builder.Services.AddScoped<UserRoleQuery>();        // Add UserRoleQuery
builder.Services.AddScoped<Tenant_Department_User_Query>(); // Add Tenant_Department_User_Query

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
app.UseCors("AllowAllOrigins");
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Add this for the GraphQL endpoint
    endpoints.MapGraphQL();  
});



app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
