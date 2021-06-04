using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            private readonly IPOSDbContext dbContext;

            public Handler(IPOSDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<InventoryAdjustment> Handle(Query request, CancellationToken cancellationToken)
            {
                var inventory = await dbContext.InventoryAdjustment.SingleOrDefaultAsync(x => x.Id == request.Id);
                return inventory;
            }
        }
    }
}
