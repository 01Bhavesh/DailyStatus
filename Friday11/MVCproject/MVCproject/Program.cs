using Microsoft.EntityFrameworkCore;
using project.Models;
using Project.Dataaccess.Repository;
using Project.Dataaccess.Server;


var builder = WebApplication.CreateBuilder(args); //create instance of webapplication sealed class


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(builder
    .Configuration.GetConnectionString("CategoryData")));

builder.Services.AddScoped<ICategory, CategoryRepo>();

builder.Services.AddScoped<IProduct, ProductRepo>();

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
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
