using System.Text.Json.Serialization;

namespace GerenciadorFinancas.Aplicacao.Dtos.DtoResponse;

public class UserLoginResponse
{

    public bool Success => Errors.Count == 0;

    public string IdUser { get; private set; }

    public string Email { get; private set; }

    public string Idioma { get; set; }

    public long TenantId { get; set; }

    public string TenantNome { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string AccessToken { get; private set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string RefreshToken { get; private set; }

    public List<string> Errors { get; private set; }

    public UserLoginResponse()
    {
        Errors = new List<string>();
    }

    public UserLoginResponse(bool success)
        : this()
    {
    }

    public UserLoginResponse(bool success, string accessToken, string refreshToken)
        : this()
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public UserLoginResponse(bool success, string accessToken, string refreshToken, string idUser, string email, string idioma, long tenantId, string tenantNome)
        : this()
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        IdUser = idUser;
        Email = email;
        Idioma = idioma;
        TenantId = tenantId;
        TenantNome = tenantNome;
    }

    public void AddError(string erro)
    {
        Errors.Add(erro);
    }

    public void AddErrors(IEnumerable<string> erros)
    {
        Errors.AddRange(erros);
    }

}

