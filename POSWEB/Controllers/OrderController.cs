using Application.Handlers.InventoryCategories.Queries;
using Application.Handlers.Orders.Queries;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]Guid id)
        {
            var response = await mediator.Send(new GetOrderById.Query { Id = id });
            if (response == null)
                return NotFound();
            else
                return Ok(response);
        }

        [HttpGet("GetOrderDetail")]
        public async Task<IActionResult> GetOrderDetali([FromQuery]Guid id)
        {
            var response = await mediator.Send(new GetOrderDetail.Query { Id = id });
            if (response == null)
                return NotFound();
            else
                return Ok(response);
        }

        [HttpGet("GetOrdersByOutlet")]
        public async Task<IActionResult> GetOrdersByOutlet([FromQuery]Guid outletId)
        {
            var response = await mediator.Send(new GetOrdersByOutlet.Query { OutletId = outletId });
            return Ok(response);
        }

        [HttpGet("GetOrdersByOutletAndOrderType")]
        public async Task<IActionResult> GetOrdersByOutletAndOrderType([FromQuery]Guid outletId, [FromQuery]OrderType orderType)
        {
            var response = await mediator.Send(new GetOrdersByOutletAndByOrderType.Query { OutletId = outletId, OrderType = orderType});
            return Ok(response);
        }
    }
}
