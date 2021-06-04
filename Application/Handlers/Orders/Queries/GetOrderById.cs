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

namespace Application.Handlers.Orders.Queries
{
    public class GetOrderById
    {
        public class Query : IRequest<OrderModel>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, OrderModel>
        {
            private readonly OrderRepository repo;
            private readonly IMapper mapper;

            public Handler(OrderRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }
            public async Task<OrderModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var order = await repo.getOrderById(request.Id);
                var resource = mapper.Map<Order, OrderModel>(order);
                return resource;
            }
        }
    }
}
