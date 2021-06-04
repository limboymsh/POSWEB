using Application.Handlers.InventoryAdjustments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryAdjustmentController : ControllerBase
    {
        private readonly IMediator mediator;
        public InventoryAdjustmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> Get([FromQuery]Guid id)
        {
            var response = await mediator.Send(new GetInventoryAdjustmentById.Query { Id = id });
            return Ok(response);
        }

        [HttpGet("getByOutlet")]
        public async Task<IActionResult> GetByOutlet([FromQuery(Name = "outletId")]Guid outletId)
        {
            var response = await mediator.Send(new GetInventoryAdjustmentsByOutlet.Query { OutletId = outletId });
            return Ok(response);
        }

        [HttpGet("GetByCompany")]
        public async Task<IActionResult> GetByCompany(Guid companyId)
        {
            var response = await mediator.Send(new GetInventoryAdjustmentsByCompany.Query { CompanyId = companyId });
            return Ok(response);
        }
    }
}