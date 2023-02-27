using GerenciadorFinancas.Dominio.Entidades;

namespace GerenciadorFinancas.Aplicacao.Interfaces.Service
{
    public class UserRegisterRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public ContaFinanceira? ContaFinanceira { get; set; }
        public List<Empresa>? Empresas { get; set; }
    }
}