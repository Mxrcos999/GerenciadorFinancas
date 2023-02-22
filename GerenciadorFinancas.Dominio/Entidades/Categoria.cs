using GerenciadorFinancas.Dominio.Entidade.core;

namespace GerenciadorFinancas.Dominio.Entidades;    

public class Categoria : EntidadeBase
{
    public string Nome { get; set; }
    public string Descricao { get; set; }

}
