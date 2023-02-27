using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;
using GerenciadorFinancas.Aplicacao.Dtos.DtoResponse;
using GerenciadorFinancas.Aplicacao.Interfaces.Repository;
using GerenciadorFinancas.Aplicacao.Interfaces.Service;
using GerenciadorFinancas.Aplicacao.UnitOfWork;
using GerenciadorFinancas.Dominio.Entidades;

namespace GerenciadorFinancas.Aplicacao.Services;

public class ContaFinanceiraService : IContaFinanceiraService
{
    private readonly IContaFinanceiraRepository _contaFinanceiraRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ContaFinanceiraService(IUnitOfWork unitOfWork, IContaFinanceiraRepository contaFinanceiraRepository)
    {
        _unitOfWork = unitOfWork;
        _contaFinanceiraRepository = contaFinanceiraRepository;
    }

    public async Task<IEnumerable<ContaFinanceiraResponse>> ObtemContasFinanceiras()
    {
        try
        {
            return await _contaFinanceiraRepository.ObterContasFinanceiras();
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<bool> IncluirContaFinanceiraAsync(ContaFinanceiraCadastroRequest model)
    {
        try
        {
            if (model == null)
                return false;
            var contaFinanceira = new ContaFinanceira(model.DataPagamento, model.ValorExtra, model.RendaBruta);
            if (await IncluirContaFinanceiraUow(contaFinanceira))
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            throw;
        }

    }
    private async Task<bool> IncluirContaFinanceiraUow(ContaFinanceira contaFinanceira)
    {
        try
        {
            if (await _contaFinanceiraRepository.IncluirContaFinanceira(contaFinanceira))
            {
                await _unitOfWork.Commit();
                return true;
            }
            return false;

        }
        catch (Exception)
        {
            await _unitOfWork.Rollback();
            throw;
        }


    }
}
