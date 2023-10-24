using Ecommerce.Data.Entities;
using Ecommerce.Data.IdentityDatabase;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// add dbcontext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<EcommerceDbContext>(options =>
    options.UseSqlServer(connectionString));

// add identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options => 
        options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<EcommerceDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

/*----------------------- Add Cookie Auth -------------------*/
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        // Javascript cannot access cookie
        option.Cookie.HttpOnly = true;
        // Cookie is always sent over HTTPS
        option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        // Redirect to Login path when user is not authenticated
        option.LoginPath = "/Authen/Login";
    });

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

// use authentication middle ware
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
