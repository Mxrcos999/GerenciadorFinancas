using GerenciadorFinancas.Aplicacao.Interfaces.Repository;
using GerenciadorFinancas.Dominio.Entidades;
using GerenciadorFinancas.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFinancas.Infraestrutura.Repository;

public class EmpresaRepository : IEmpresaRepository
{

    private readonly GerenciadorContext _context;
    private readonly DbSet<Empresa> _empresa;

    public EmpresaRepository(GerenciadorContext context)
    {
        _context = context;
        _empresa = context.Set<Empresa>();
    }
    public async Task<bool> IncluirEmpresa(Empresa empresa)
    {
        try
        {
            await _empresa.AddAsync(empresa);
            _context.SaveChanges();
            return true;    
        }
        catch (Exception) { throw;}
    }
}
