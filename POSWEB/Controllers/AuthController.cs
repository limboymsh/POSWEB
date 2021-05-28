using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Services.Interfaces;
using WebUI.DTO;
using System;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        public AuthController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
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
                var token = await jwtAuthenticationManager.authenticate(userCred);

                return Ok(token);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
