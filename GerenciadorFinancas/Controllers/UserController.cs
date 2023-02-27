using GerenciadorFinancas.Aplicacao.Dtos.DtoPost;
using GerenciadorFinancas.Aplicacao.Interfaces.Service;
using GerenciadorFinancas.Identity.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinancasApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : Controller
    {
        private readonly IIdentityService _identityService;
        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("Users")]
        public async Task<IActionResult> RegisterUser(UserRegisterRequest model)
        {
            if(!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.RegisterUserAsync(model);
            if (result) 
                return Ok(result);
            return BadRequest();    
        } 
        
        [HttpPost]
        [Route("Users/login")]
        public async Task<IActionResult> Login(UserLoginRequest model)
        {
            if(!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);

            var result = await _identityService.LoginAsync(model);
            if (result.Success) 
                return Ok(result);
            return BadRequest();    
        }
    }
}
