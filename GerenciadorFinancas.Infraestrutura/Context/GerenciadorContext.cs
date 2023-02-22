using GerenciadorFinancas.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFinancas.Infraestrutura.Context;
public class GerenciadorContext : DbContext
{
	public GerenciadorContext(DbContextOptions<GerenciadorContext> options) : base(options) { }
	public DbSet<Usuario> usuarios { get; set; }
	public DbSet<ContaFinanceira> contaFinanceiras { get; set; }
	public DbSet<Empresa> empresas { get; set; }
	public DbSet<Dispesa> dispesas { get; set; }
	public DbSet<Categoria> categorias { get; set; }
}

