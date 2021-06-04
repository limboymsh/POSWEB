using Application.Common.Models;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Inventories.Queries
{
    public class GetInventoryById
    {
        public class Query : IRequest<InventoryModel>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, InventoryModel>
        {
            private readonly InventoryRepository repo;
            private readonly IMapper mapper;

            public Handler(InventoryRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }
            public async Task<InventoryModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var inventory = await repo.GetInventoryById(request.Id);
                
                var resources = mapper.Map<Inventory, InventoryModel>(inventory);
                return resources;
            }
        }
    }
}
