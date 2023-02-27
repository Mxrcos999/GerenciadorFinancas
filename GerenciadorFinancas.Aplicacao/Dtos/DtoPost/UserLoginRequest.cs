using System.ComponentModel.DataAnnotations;

namespace GerenciadorFinancas.Aplicacao.Dtos.DtoPost
{
    public class UserLoginRequest
    {
        [Required]
        public string Email { get; set; } 
        [Required]
        public string Password { get; set; }
    }
}