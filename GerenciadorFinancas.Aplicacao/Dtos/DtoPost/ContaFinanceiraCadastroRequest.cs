namespace GerenciadorFinancas.Aplicacao.Dtos.DtoPost;

public class ContaFinanceiraCadastroRequest
{
    public decimal RendaBruta { get; set; }
    public decimal ValorExtra { get; set; }
    public DateTime? DataPagamento { get; set; }
}
