using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;
using GerenciadorFinancas.Aplicacao.Interfaces.Repository;
using GerenciadorFinancas.Aplicacao.Interfaces.Service;
using GerenciadorFinancas.Aplicacao.UnitOfWork;
using GerenciadorFinancas.Dominio.Entidades;

namespace GerenciadorFinancas.Aplicacao.Services;

public class EmpresaService : IEmpresaService
{
	private readonly IEmpresaRepository _empresaRepository;
	private readonly IUnitOfWork _unitOfWork;
	public EmpresaService(IEmpresaRepository empresaRepository, IUnitOfWork unitOfWork)
	{
		_empresaRepository = empresaRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<bool> IncluirEmpresa(EmpresaCadastroRequest empresaModel)
	{
		try
		{
			if (empresaModel == null)
				return false;
			var empresa = new Empresa(empresaModel.ValorPago, empresaModel.EmpresaAtual, empresaModel.Nome);
			if (await IncluirEmpresaUow(empresa))
				return true;
			else
				return false;
		}
		catch (Exception)
		{
			throw;
		}

	}
	private async Task<bool> IncluirEmpresaUow(Empresa empresa)
	{
		try
		{
			if(await _empresaRepository.IncluirEmpresa(empresa))
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
