using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Server;
using New_CRUDTask.ServiceImplementation;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(op =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        In = ParameterLocation.Header,
        Description = "Enter JWT to authenticate.",
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = JwtBearerDefaults.AuthenticationScheme }
    };
    op.AddSecurityDefinition("Bearer", securityScheme);
    op.AddSecurityRequirement(new OpenApiSecurityRequirement { { securityScheme, new string[] { } } });
});

builder.Services.AddDbContext<DbContextServer>(o =>  
o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //Sets the default data to use when a specific data isn't requested
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddAuthentication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
