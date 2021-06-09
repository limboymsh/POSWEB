using System;
using System.Threading.Tasks;
using Application.Handlers.Inventories.Commands.Create;
using Application.Handlers.Inventories.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

namespace WebUI.Controllers
{

    [Authorize]
    public class InventoryController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public InventoryController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        #region GET
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
        public async Task<IActionResult> GetByCompany([BindRequired]Guid companyId)
        {
            var response = await mediator.Send(new GetInventoriesByCompany.Query { CompanyId = companyId });
            return Ok(response);
        }

        #endregion

        #region Create
        [HttpPost("createInventory")]
        public async Task<IActionResult> CreateIntentory([FromBody] CreateInventoryDTO inventory)
        {
            return Ok(await mediator.Send(mapper.Map<CreateInventoryDTO, CreateInventoryCommand>(inventory,
                opts => opts.InjectAuthrizationUserOnly(UserData))));
        }
        #endregion
    }
}