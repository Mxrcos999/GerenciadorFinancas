namespace GerenciadorFinancas.Aplicacao.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
    Task Rollback();
}
