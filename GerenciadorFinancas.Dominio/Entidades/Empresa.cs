using GerenciadorFinancas.Dominio.Entidade.core;

namespace GerenciadorFinancas.Dominio.Entidades;

public class Empresa : EntidadeBase
{
    public string Nome { get; set; }
    public bool EmpresaAtual { get; set; }
    public decimal ValorPago { get; set; }

    public Empresa(decimal valorPago, bool empresaAtual, string nome)
    {
        ValorPago = valorPago;
        EmpresaAtual = empresaAtual;
        Nome = nome;
    }
}
