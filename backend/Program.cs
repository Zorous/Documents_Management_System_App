using backend.Database;
using backend.GraphQL.QueryType;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure GraphQL integration
builder.Services.AddGraphQLServer().AddQueryType<Query>();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    var connectionString = builder.Configuration.GetConnectionString("MyAppCs");
    builder.Services.AddDbContext<AppDbContext>(options =>
    //POSTGREY Integration
        options.UseNpgsql(connectionString));
}


//GraphQL Integration
app.MapGraphQL();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
