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
    public class GetInventoryAdjustmentById
    {
        public class Query : IRequest<InventoryAdjustment>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, InventoryAdjustment>
        {
            private readonly InventoryRepository repo;

            public Handler(InventoryRepository repo)
            {
                this.repo = repo;
            }
            public async Task<InventoryAdjustment> Handle(Query request, CancellationToken cancellationToken)
            {
                return await repo.GetInventoryAdjustmentById(request.Id);
            }
        }
    }
}
