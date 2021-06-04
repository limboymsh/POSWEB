using Application.Common.Models;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.InventoryCategories.Queries
{
    public class GetInventoryCategoriesByOutlet
    {
        public class Query : IRequest<IEnumerable<InventoryCategoryModel>>
        {
            public Guid OutletId { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<InventoryCategoryModel>>
        {
            private readonly InventoryRepository repo;
            private readonly IMapper mapper;

            public Handler(InventoryRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }
            public async Task<IEnumerable<InventoryCategoryModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var inveotoryCategories = await repo.GetInventoryCategoriesByOutlet(request.OutletId);
                var resources = mapper.Map<IEnumerable<InventoryCategory>, IEnumerable<InventoryCategoryModel>>(inveotoryCategories);
                return resources;
            }
        }
    }
}
