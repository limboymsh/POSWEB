using Application.Handlers.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    /*[Authorize]*/
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await mediator.Send(new GetUsers.GetUsersQuery());
            return Ok(response);
        }

        [HttpGet("getUserByEmailPass")]
        public async Task<IActionResult> GetUsersdata([FromQuery]string email, [FromQuery] string pass)
        {
            var response = await mediator.Send(new GetUserQuery { Email = email, Password = pass });
            return Ok(response);
        }

        [HttpGet("{email}")]

        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var response = await mediator.Send(new GetUserByEmail.GetUserByEmaliQuery { Email = email });
            Console.WriteLine("header - -====== " + Request.Headers);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}
