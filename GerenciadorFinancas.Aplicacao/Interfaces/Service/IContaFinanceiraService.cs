using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;
using GerenciadorFinancas.Aplicacao.Dtos.DtoResponse;

namespace GerenciadorFinancas.Aplicacao.Interfaces.Service;

public interface IContaFinanceiraService
{
    Task<bool> IncluirContaFinanceiraAsync(ContaFinanceiraCadastroRequest model);
    Task<IEnumerable<ContaFinanceiraResponse>> ObtemContasFinanceiras();
}
