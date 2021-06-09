using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.DTO;
using System;
using WebUI.Services;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/register")]
        public IActionResult Register([FromBody] UserRegisterDTO user)
        {
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredDTO userCred)
        {
            try
            {
                var token = await authService.GetAccessTokenAsync(userCred);
                return Ok(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
