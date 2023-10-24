using System.Reflection;
using Ecommerce.Data.Entities;
using Ecommerce.Data.IdentityDatabase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// configure swagger authen for test api
builder.Services.AddSwaggerGen(options =>
{
    // options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    // {
    //     Name = "Authorization",
    //     In = ParameterLocation.Header,
    //     Description = "Please enter your token with this format: ''Bearer YOUR_TOKEN''",
    //     Type = SecuritySchemeType.ApiKey,
    //     BearerFormat = "JWT",
    //     Scheme = "bearer",
    // });
    // options.AddSecurityRequirement(new OpenApiSecurityRequirement
    // {
    //     {
    //         new OpenApiSecurityScheme
    //         {
    //             Name = "Bearer",
    //             In = ParameterLocation.Header,
    //             Reference = new OpenApiReference
    //             {
    //                 Id = "Bearer",
    //                 Type = ReferenceType.SecurityScheme
    //             }
    //         },
    //         new List<string>()
    //     }
    // });

    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Petshop service api",
        Description = "Sample .NET api by ",
        Contact = new OpenApiContact()
        {
            Name = "Hoang Trong Tam",
            Url = new Uri("https://www.youtube.com")
        }
    });
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var path = Path.Combine(AppContext.BaseDirectory, xmlFileName);
    options.IncludeXmlComments(path);
});


// add dbcontext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<EcommerceDbContext>(options => 
    options.UseSqlServer(connectionString));

// add identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options => 
        options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<EcommerceDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();