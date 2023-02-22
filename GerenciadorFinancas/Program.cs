using GerenciadorFinancas.Aplicacao.Interfaces.Repository;
using GerenciadorFinancas.Aplicacao.Interfaces.Service;
using GerenciadorFinancas.Aplicacao.Services;
using GerenciadorFinancas.Aplicacao.UnitOfWork;
using GerenciadorFinancas.Infraestrutura.Context;
using GerenciadorFinancas.Infraestrutura.Repository;
using GerenciadorFinancas.Infraestrutura.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GerenciadorContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

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
