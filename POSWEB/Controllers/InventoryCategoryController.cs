using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handlers.Inventorycategories.Commands.CreateInventoryCategory;
using Application.Handlers.InventoryCategories.Queries;
using Application.Handlers.Orders.Queries;
using AutoMapper;
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
        private readonly IMapper mapper;

        public InventoryCategoryController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery]Guid id)
        {
            var response = await mediator.Send(new GetInventoryCategoryById.Query {Id = id});
            return Ok(response);
        }

        [HttpGet("getByOutlet")]
        public async Task<IActionResult> GetByOutlet([FromQuery(Name = "outletId")]Guid outletId)
        {
            var response = await mediator.Send(new GetInventoryCategoriesByOutlet.Query { OutletId = outletId });
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