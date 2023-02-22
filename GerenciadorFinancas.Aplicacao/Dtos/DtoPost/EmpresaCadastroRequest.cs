namespace GerenciadorFinancas.Aplicacao.Dtos.DtoPost;

public class EmpresaCadastroRequest
{
    public string Nome { get; set; }
    public bool EmpresaAtual { get; set; }
    public decimal ValorPago { get; set; }
}
