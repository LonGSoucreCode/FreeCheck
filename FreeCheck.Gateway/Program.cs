using FreeCheck.Repository.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FreeCheck.BusinessLogic;
using FreeCheck.DTO.Params;
using FreeCheck.DTO.Results;
using FreeCheck.Repository.Infrastructure.Repositories.Implements;
using FreeCheck.Repository.Infrastructure.Repositories.Interfaces;
using FreeCheck.BusinessLogic.GhoeCheckLogic;
using Serilog;
using FreeCheck.BusinessLogic.AuthenticateLogic;
using FreeCheck.Helper.JwtToken;
using FreeCheck.Gateway.Middlewares;


var configuration = GetConfiguration();
var builder = WebApplication.CreateBuilder(args);

// Add Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    // option.SwaggerDoc("v1", new OpenApiInfo { Title = "CTV PRODUCT" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

RegisterLogger(builder);

RegisterLogic(builder);

RegisterRepository(builder);

RegisterLibraries(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();


static IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
    return builder.Build();
}
static void RegisterLogic(WebApplicationBuilder builder)
{
    //Start Authenticate
    builder.Services.AddScoped<ILogic<LoginParam, LoginResult>, LoginLogic>();
    //End

    //Start Shoe Check
    builder.Services.AddScoped<ILogic<GetListShoeCheckParam, GetListShoeCheckResult>, GetListShoeCheckLogic>();
    //End
}
static void RegisterRepository(WebApplicationBuilder builder)
{
    // Add Configuration
    builder.Services.AddDbContext<FreeCheckDbContext>(option => option.UseSqlServer("name=ConnectionStrings:FreeCheckDb"));
    builder.Services.AddScoped<IShoeCheckRepository, ShoeCheckRepository>();
}
static void RegisterLogger(WebApplicationBuilder builder)
{
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration).CreateLogger();
    builder.Host.UseSerilog();
}
static void RegisterLibraries(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IJwtToken, JwtToken>();
    //builder.Services.AddTransient<AuthorizeAdminAttribute>();
    //builder.Services.AddTransient<AuthorizeUserAttribute>();
}