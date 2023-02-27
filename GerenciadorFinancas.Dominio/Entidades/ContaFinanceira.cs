using GerenciadorFinancas.Dominio.Entidade.core;

namespace GerenciadorFinancas.Dominio.Entidades
{
    public class ContaFinanceira : EntidadeBase
    {
        public decimal RendaBruta { get; set; }
        public decimal ValorExtra { get; set; }    
        public DateTime? DataPagamento { get; set; }
        public ContaFinanceira(DateTime? dataPagamento, decimal valorExtra, decimal rendaBruta)
        {
            DataPagamento = dataPagamento;
            ValorExtra = valorExtra;
            RendaBruta = rendaBruta;
        }
    }
}
