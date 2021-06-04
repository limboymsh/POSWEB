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
    public class GetInventoryCategoryById
    {
        public class Query : IRequest<InventoryCategoryModel>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, InventoryCategoryModel>
        {
            private readonly IMapper mapper;
            private readonly InventoryRepository repo;

            public Handler(InventoryRepository repo, IMapper mapper)
            {
                this.mapper = mapper;
                this.repo = repo;
            }
            public async Task<InventoryCategoryModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var inveotoryCategory = await repo.GetInventoryCategoryById(request.Id);
                var resources = mapper.Map<InventoryCategory, InventoryCategoryModel>(inveotoryCategory);
                return resources;
            }
        }
    }
}
