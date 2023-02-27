using Microsoft.AspNetCore.Identity;

namespace GerenciadorFinancas.Dominio.Entidades;

public class ApplicationUser : IdentityUser
{
    public string Nome { get; set; }
    public ContaFinanceira ContaFinanceira { get; set; }
    public List<Empresa> Empresas { get; set; }
}
