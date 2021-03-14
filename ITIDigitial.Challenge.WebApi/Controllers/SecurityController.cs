using ITIDigitial.Challenge.Application.Interfaces.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ITIDigitial.Challenge.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityApplicationService _securityApplicationService;

        public SecurityController(ISecurityApplicationService securityApplicationService)
        {
            _securityApplicationService = securityApplicationService;
        }

        /// <summary>
        /// Validar senha.
        /// </summary>
        /// <remarks>
        /// Pré requisitos da senha:
        /// 
        /// 1. Nove ou mais caracteres
        /// 2. Ao menos 1 dígito
        /// 3. Ao menos 1 letra minúscula
        /// 4. Ao menos 1 letra maiúscula
        /// 5. Ao menos 1 caractere especial (!@#$%^*()-+)
        /// 6. Não possuir caracteres repetidos dentro do conjunto
        /// </remarks>
        /// <param name="password"></param>
        /// <response code="200">Senha válida</response>
        /// <response code="400">Senha inválida</response>
        [HttpGet]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 400)]
        public async Task<IActionResult> Get(string password)
            => await _securityApplicationService.ValidatePasswordAsync(password) ? Ok(true) : BadRequest(false);
    }
}
