using System.Data.Common;
using System.Text;
using Authentication.IServiceImplementation;
using Authentication.Server;
using Authentication.ServiceImplementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(op =>
{
    var securitySchema = new OpenApiSecurityScheme
    {
        BearerFormat ="Jwt",
        Name ="Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        In =ParameterLocation.Header,
        Description ="Enter Jwt token for Authentication",
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme , Id =JwtBearerDefaults.AuthenticationScheme}
        };
    op.AddSecurityDefinition("Bearer", securitySchema);
    op.AddSecurityRequirement(new OpenApiSecurityRequirement { { securitySchema, new string[] { } } });
});

builder.Services.AddDbContext<DbServer>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(op =>
    {
        op.TokenValidationParameters = new TokenValidationParameters
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
