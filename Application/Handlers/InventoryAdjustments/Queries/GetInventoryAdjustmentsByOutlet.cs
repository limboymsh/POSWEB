using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.InventoryAdjustments.Queries
{
    public class GetInventoryAdjustmentsByOutlet
    {
        public class Query : IRequest<IEnumerable<InventoryAdjustment>>
        {
            public Guid OutletId { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<InventoryAdjustment>>
        {
            private readonly InventoryRepository repo;

            public Handler(InventoryRepository repo)
            {
                this.repo = repo;
            }
            public async Task<IEnumerable<InventoryAdjustment>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await repo.GetInventoryAdjustmentsByOutlet(request.OutletId);
            }
        }
    }
}
