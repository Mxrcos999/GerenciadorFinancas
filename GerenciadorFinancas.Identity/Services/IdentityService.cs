using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;
using GerenciadorFinancas.Aplicacao.Dtos.DtoResponse;
using GerenciadorFinancas.Dominio.Entidades;
using GerenciadorFinancas.Identity.Configuration;
using GerenciadorFinancas.Identity.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GerenciadorFinancas.Aplicacao.Interfaces.Service;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtOptions _jwtOptions;

    public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<UserLoginResponse> LoginAsync(UserLoginRequest userLogin)
    {
        SignInResult signInResult = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, isPersistent: false, lockoutOnFailure: true);
        if (signInResult.Succeeded)
            return await GerarCredenciais(userLogin.Email);


        UserLoginResponse userLoginResponse = new UserLoginResponse(signInResult.Succeeded);
        if (!signInResult.Succeeded)
        {
            if (signInResult.IsLockedOut)
            {
                userLoginResponse.AddError("This account is locked.");
            }
            else if (signInResult.IsNotAllowed)
            {
                userLoginResponse.AddError("This account doesn't have permission to sign-in.");
            }
            else if (signInResult.RequiresTwoFactor)
            {
                userLoginResponse.AddError("Confirm your sign-in.");
            }
            else
            {
                userLoginResponse.AddError("Username or password is incorrect.");
            }
        }

        return userLoginResponse;
    }

    public async Task<bool> RegisterUserAsync(UserRegisterRequest userRegister)
    {
        ApplicationUser applicationUser = new ApplicationUser
        {
            UserName = userRegister.Email,
            Email = userRegister.Email,
            EmailConfirmed = true,
            Nome = userRegister.Nome,
            PasswordHash = userRegister.Senha,
            ContaFinanceira = userRegister.ContaFinanceira,
            Empresas = userRegister.Empresas
        };
        IdentityResult result = await _userManager.CreateAsync(applicationUser, userRegister.Senha);
        if (result.Succeeded)
            return true;

        return false;
    }
    private async Task<UserLoginResponse> GerarCredenciais(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var accessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true);
        var refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false);

        var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
        var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

        var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
        var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

        return new UserLoginResponse
        (
            success: true,
            accessToken: accessToken,
            refreshToken: refreshToken
        );
    }

    private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
    {
        JwtSecurityToken token = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, claims, DateTime.Now, dataExpiracao, _jwtOptions.SigningCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<IList<Claim>> ObterClaims(ApplicationUser user, bool adicionarClaimsUsuario)
    {
        var claims = new List<Claim>();

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        if (adicionarClaimsUsuario)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            foreach (var role in roles)
                claims.Add(new Claim("role", role));
        }

        return claims;
    }

}
