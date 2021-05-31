using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Inventories.Queries
{
    public class GetInventoryById
    {
        public class Query : IRequest<Inventory>
        {
            public Guid Id { get; set; }
        }

        public class handler : IRequestHandler<Query, Inventory>
        {
            private readonly IPOSDbContext dbContext;

            public handler(IPOSDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task<Inventory> Handle(Query request, CancellationToken cancellationToken)
            {
                var inventory = await dbContext.Inventory.SingleOrDefaultAsync(x => x.Id == request.Id);
                return inventory;
            }
        }
    }
}
