namespace GerenciadorFinancas.Dominio.Entidade.core;

public class EntidadeBase
{
    public int Id { get; set; }
    public DateTime DataHoraCadastro { get; set; }
    public DateTime? DataHoraAlteracao { get; set; }
}

