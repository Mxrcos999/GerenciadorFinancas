using GerenciadorFinancas.Aplicacao.Dtos.DtoResponse;
using GerenciadorFinancas.Dominio.Entidades;

namespace GerenciadorFinancas.Aplicacao.Interfaces.Repository;

public interface IContaFinanceiraRepository
{
    Task<bool> IncluirContaFinanceira(ContaFinanceira conta);
    Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras();
}
