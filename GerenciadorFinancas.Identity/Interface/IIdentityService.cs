using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;
using GerenciadorFinancas.Aplicacao.Dtos.DtoResponse;
using GerenciadorFinancas.Aplicacao.Interfaces.Service;

namespace GerenciadorFinancas.Identity.Interface;

public interface IIdentityService
{
    Task<UserLoginResponse> LoginAsync(UserLoginRequest userLogin);
    Task<bool> RegisterUserAsync(UserRegisterRequest userRegister);
}
