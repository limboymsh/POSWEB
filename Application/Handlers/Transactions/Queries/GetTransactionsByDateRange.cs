using Application.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Transactions.Queries
{
    public class GetTransactionsByDateRange
    {
        public class Query : IRequest<IEnumerable<Transaction>>
        {
            public Guid OutletId { get; set; }
            public DateTime FromDate{ get; set; }
            public DateTime ToDate{ get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<Transaction>>
        {
            private readonly TransactionRepository repo;

            public Handler(TransactionRepository repo)
            {
                this.repo = repo;
            }
            public async Task<IEnumerable<Transaction>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await repo.getTransactionsByDateRange(request.OutletId, request.FromDate, request.ToDate);
            }
        }
    }
}
