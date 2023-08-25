using Heroes.App.Databases;
using Microsoft.EntityFrameworkCore;
using Heroes.App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


/*builder.Services.AddDbContext<HeroContext>(options =>
{
    //options.UseInMemoryDatabase("MyDatabase"); 
});*/
var conectionString = builder.Configuration.GetConnectionString("PostgreSQL");


builder.Services.AddDbContext<HeroContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
});


var app = builder.Build();

//Helper.AddHeroesData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();