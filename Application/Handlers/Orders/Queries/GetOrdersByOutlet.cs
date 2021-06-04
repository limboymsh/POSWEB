

using Application.Common.Models;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Orders.Queries
{
    public class GetOrdersByOutlet
    {
        public class Query : IRequest<IEnumerable<OrderModel>>
        {
            public Guid OutletId { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<OrderModel>>
        {
            private readonly OrderRepository repo;
            private readonly IMapper mapper;

            public Handler(OrderRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }
            public async Task<IEnumerable<OrderModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var orders = await repo.getOrdersByOutlet(request.OutletId);
                var resources = mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(orders);
                return resources;
            }
        }
    }
}
