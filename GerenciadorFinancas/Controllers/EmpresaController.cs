using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;
using GerenciadorFinancas.Aplicacao.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinancasApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;
        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }
        [HttpGet]
        [Route("empresas")]
        public async Task<IActionResult> BuscaEmpresas()
        {
            return Ok();
        }

        [HttpPost]
        [Route("empresas")]
        public async Task<IActionResult> IncluirEmpresa(EmpresaCadastroRequest model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _empresaService.IncluirEmpresa(model);

            if (!result)
                return StatusCode(StatusCodes.Status400BadRequest);

            return Ok();

        }
    }
}
