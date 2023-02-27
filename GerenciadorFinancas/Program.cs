using GerenciadorFinancas.Aplicacao.Interfaces.Repository;
using GerenciadorFinancas.Aplicacao.Interfaces.Service;
using GerenciadorFinancas.Aplicacao.Services;
using GerenciadorFinancas.Aplicacao.UnitOfWork;
using GerenciadorFinancas.Dominio.Entidades;
using GerenciadorFinancas.Identity.Interface;
using GerenciadorFinancas.Infraestrutura.Context;
using GerenciadorFinancas.Infraestrutura.Repository;
using GerenciadorFinancas.Infraestrutura.UnitOfWork;
using GerenciadorFinancasApi.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                                Enter 'Bearer' [space] and then your token in the text input below. 
                                Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
    });
});



builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddAuthorization(opts => opts.AddPolicy("RequireLoggedIn", policy => policy.RequireAuthenticatedUser()));
builder.Services.AddDbContext<GerenciadorContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("connection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddDefaultTokenProviders()
           .AddDefaultUI()
           .AddEntityFrameworkStores<GerenciadorContext>()
           .AddDefaultTokenProviders()
           .AddUserManager<UserManager<ApplicationUser>>()
           .AddSignInManager<SignInManager<ApplicationUser>>();

builder.Services.AddScoped<IIdentityService, IdentityService>();



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IContaFinanceiraService, ContaFinanceiraService>();
builder.Services.AddScoped<IContaFinanceiraRepository, ContaFinanceiraRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization();
});

app.Run();
