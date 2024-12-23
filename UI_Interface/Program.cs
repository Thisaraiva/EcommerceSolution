using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Extensions;
using Infrastructure.Identity;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EcommerceSolutionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EcommerceSolutionDbContext>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/Login");

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed roles and admin user
await app.SeedRolesAndAdminAsync(); // Chamando o m�todo de extens�o

app.Run();
