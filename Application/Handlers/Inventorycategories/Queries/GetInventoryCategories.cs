using Application.Repositories;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Inventorycategories.Queries
{
    public class GetInventoryCategories
    {
        public class Query : IRequest<IEnumerable<InventoryCategory>>
        {
        }

        public class Handler : IRequestHandler<Query, IEnumerable<InventoryCategory>>
        {
            private readonly InventoryCategoryRepository repo;

            public Handler(InventoryCategoryRepository repo)
            {
                this.repo = repo;
            }
            public async Task<IEnumerable<InventoryCategory>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await repo.GetAllInventryCategory();
            }
        }
    }
}
