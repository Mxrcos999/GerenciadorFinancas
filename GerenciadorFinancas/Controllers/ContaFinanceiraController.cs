using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;
using GerenciadorFinancas.Aplicacao.Interfaces.Service;
using GerenciadorFinancas.Aplicacao.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinancasApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class ContaFinanceiraController : Controller
    {
        private readonly IContaFinanceiraService _contaFinanceiraService;

        public ContaFinanceiraController(IContaFinanceiraService contaFinanceiraService)
        {
            _contaFinanceiraService = contaFinanceiraService;
        }

        [Authorize("RequireLoggedIn")]
        [HttpPost]
        [Route("contasFinanceiras")]
        public async Task<IActionResult> IncluirContaFinanceiraAsync(ContaFinanceiraCadastroRequest model)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _contaFinanceiraService.IncluirContaFinanceiraAsync(model);

            if (!result)
                return StatusCode(StatusCodes.Status400BadRequest);

            return Ok();

        }      
        
        [Authorize("RequireLoggedIn")]
        [HttpGet]
        [Route("contasFinanceiras")]
        public async Task<IActionResult> ObterContasFinanceirasAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(StatusCodes.Status400BadRequest);

                var result = await _contaFinanceiraService.ObtemContasFinanceiras();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
                throw;
            }
    

        }
    }
}
