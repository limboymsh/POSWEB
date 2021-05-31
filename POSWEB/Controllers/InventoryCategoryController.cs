using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handlers.Inventorycategories.Commands.CreateInventoryCategory;
using Application.Handlers.Inventorycategories.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryCategoryController : ControllerBase
    {

        private readonly IMediator mediator;
        public InventoryCategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /*[HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await mediator.Send(new GetInventoryById.Query { Id = id });
            return Ok(response);
        }*/
        [HttpGet]
        public async Task<IActionResult> GetAllInventoryCategories()
        {
            var response = await mediator.Send(new GetInventoryCategories.Query());
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody]InventoryCategory category)
        {
            Console.WriteLine("'''''''''''''''''''''''-'''''''''''''''''''''''''''");
            var response = await mediator.Send(new CreateInventoryCategoryCommand { Category = category });
            return Ok(response);
        }

    }
}