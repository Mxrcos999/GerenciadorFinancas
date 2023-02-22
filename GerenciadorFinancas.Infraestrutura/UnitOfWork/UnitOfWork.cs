using GerenciadorFinancas.Aplicacao.UnitOfWork;
using GerenciadorFinancas.Infraestrutura.Context;

namespace GerenciadorFinancas.Infraestrutura.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly GerenciadorContext _context;

    public UnitOfWork(GerenciadorContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        var sucess = (await _context.SaveChangesAsync()) > 0;
        return sucess;
    }

    public void Dispose() =>
   _context.Dispose();

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
