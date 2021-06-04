using Application.Common.Models;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Inventories.Queries
{
    public class GetInventoriesByCompany
    {
        public class Query : IRequest<IEnumerable<InventoryModel>>
        {
            public Guid CompanyId { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<InventoryModel>>
        {
            private readonly InventoryRepository repo;
            private readonly IMapper mapper;

            public Handler(InventoryRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }
            public async Task<IEnumerable<InventoryModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var inventories = await repo.GetInventoriesByCompany(request.CompanyId);
                var resources = mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryModel>>(inventories);
                return resources;
            }
        }
    }
}
