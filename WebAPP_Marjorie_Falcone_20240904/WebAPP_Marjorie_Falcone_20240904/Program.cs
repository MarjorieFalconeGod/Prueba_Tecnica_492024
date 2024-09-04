using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPP_Marjorie_Falcone_20240904.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebAPP_Marjorie_Falcone_20240904Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAPP_Marjorie_Falcone_20240904Context") ?? throw new InvalidOperationException("Connection string 'WebAPP_Marjorie_Falcone_20240904Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
