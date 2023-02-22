using GerenciadorFinancas.Dominio.Entidades;

namespace GerenciadorFinancas.Aplicacao.Interfaces.Repository;

public interface IEmpresaRepository
{
    Task<bool> IncluirEmpresa(Empresa empresa);
}
