using GerenciadorFinancas.Aplicacao.Dtos.DtoResponse;
using GerenciadorFinancas.Aplicacao.Interfaces.Repository;
using GerenciadorFinancas.Dominio.Entidades;
using GerenciadorFinancas.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFinancas.Infraestrutura.Repository;

public class ContaFinanceiraRepository : IContaFinanceiraRepository
{

    private readonly GerenciadorContext _context;
    private readonly DbSet<ContaFinanceira> _contaFinanceiras;

    public ContaFinanceiraRepository(GerenciadorContext context)
    {
        _context = context;
        _contaFinanceiras = context.Set<ContaFinanceira>();
    }

    public async Task<bool> IncluirContaFinanceira(ContaFinanceira conta)
    {
        try
        {
            await _contaFinanceiras.AddAsync(conta);
            _context.SaveChanges();
            return true;
        }
        catch (Exception) { throw; }
    }  
    public async Task<IEnumerable<ContaFinanceiraResponse>> ObterContasFinanceiras()
    {
        try
        {
            var contas = from Contas in _contaFinanceiras
                .AsNoTracking()
                         select new ContaFinanceiraResponse()
                         {
                             DataPagamento = Contas.DataPagamento,
                             RendaBruta = Contas.RendaBruta,
                             ValorExtra = Contas.ValorExtra
                         };
            return contas.AsEnumerable();
        }
        catch (Exception) { throw; }
    }
}
