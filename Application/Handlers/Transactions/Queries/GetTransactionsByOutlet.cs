using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Transactions.Queries
{
    public class GetTransactionsByOutlet
    {
        public class Query : IRequest<IEnumerable<Transaction>>
        {
            public Guid OutletId { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Transaction>>
        {
            private readonly TransactionRepository repo;

            public Handler(TransactionRepository repo)
            {
                this.repo = repo;
            }
            public Task<IEnumerable<Transaction>> Handle(Query request, CancellationToken cancellationToken)
            {
                return repo.getTransactionByOutlet(request.OutletId);
            }
        }
    }
}
