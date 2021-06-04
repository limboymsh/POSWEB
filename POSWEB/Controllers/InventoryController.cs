using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handlers.Inventories.Queries;
using Application.Handlers.InventoryAdjustments.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public InventoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery]Guid id)
        {
            var response = await mediator.Send(new GetInventoryById.Query { Id = id });
            return Ok(response);
        }

        [HttpGet("getByOutlet")]
        public async Task<IActionResult> GetByOutlet([FromQuery(Name = "outletId")]Guid outletId)
        {
            var response = await mediator.Send(new GetInventoriesByOutlet.Query { OutletId = outletId });
            return Ok(response);
        }

        [HttpGet("GetByCompany")]
        public async Task<IActionResult> GetByCompany(Guid companyId)
        {
            var response = await mediator.Send(new GetInventoriesByCompany.Query { CompanyId = companyId });
            return Ok(response);
        }
    }
}