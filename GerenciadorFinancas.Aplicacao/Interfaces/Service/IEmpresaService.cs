using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;

namespace GerenciadorFinancas.Aplicacao.Interfaces.Service;

public interface IEmpresaService
{
    Task<bool> IncluirEmpresa(EmpresaCadastroRequest empresaModel);
}
