using GerenciadorFinancas.Dominio.Entidade.core;

namespace GerenciadorFinancas.Dominio.Entidades;

public class Dispesa : EntidadeBase
{
    public decimal Valor { get; set; }
    public DateTime? Previsao { get; set; }
    public List<Categoria> Categorias { get; set; }

}
