using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Inventories.Commands.Create
{

    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, Unit>
    {
        private readonly InventoryRepository repo;

        public CreateInventoryCommandHandler(InventoryRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Unit> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            Inventory inventory = new Inventory()
            {
                Id = Guid.NewGuid(),
                CompanyId = request.CompanyId,
                Name = request.Name,
                OutletId = request.OutletId,
                Stock = request.Stock,
                CreatedBy = request.User.Id,
                UpdateBy = request.User.Id,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            await repo.CreateInventory(inventory, cancellationToken);
            return Unit.Value;
        }
    }
}
