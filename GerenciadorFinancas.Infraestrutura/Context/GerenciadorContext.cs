using GerenciadorFinancas.Dominio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GerenciadorFinancas.Infraestrutura.Context;
public class GerenciadorContext : IdentityDbContext<ApplicationUser>
{
	public GerenciadorContext(DbContextOptions<GerenciadorContext> options) : base(options) { }
	public DbSet<ApplicationUser> User { get; set; }
	public DbSet<ContaFinanceira> contaFinanceiras { get; set; }
	public DbSet<Empresa> empresas { get; set; }
	public DbSet<Dispesa> dispesas { get; set; }
	public DbSet<Categoria> categorias { get; set; }
}
public class ToDoContextFactory : IDesignTimeDbContextFactory<GerenciadorContext>
{
    public GerenciadorContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<GerenciadorContext>();
        builder.UseNpgsql("Host=localhost;Port=5432;Database=gerenciadorFinancas;Username=postgres;Password=12345");
        return new GerenciadorContext(builder.Options);
    }
}

