using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Handlers.Transactions.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("getByOutlet")]
        public async Task<IActionResult> GetByOutlet([FromQuery]Guid outletId)
        {
            var transactions = await mediator.Send(new GetTransactionsByOutlet.Query { OutletId = outletId });
            return Ok(transactions);
        }

        [HttpGet("getByDateRange")]
        public async Task<IActionResult> GetByDateRange([FromQuery]Guid outletId, [FromQuery]DateTime fromDate, [FromQuery]DateTime toDate)
        {
            var transactions = await mediator.Send(new GetTransactionsByDateRange.Query{OutletId = outletId, FromDate = fromDate, ToDate = toDate });
            return Ok(transactions);
        }
    }
}