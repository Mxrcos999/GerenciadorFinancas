using GerenciadorFinancas.Dominio.Entidade.core;

namespace GerenciadorFinancas.Dominio.Entidades;

public class Usuario : EntidadeBase
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public ContaFinanceira ContaFinanceira { get; set; }
    public List<Empresa> Empresas { get; set; } 
}
