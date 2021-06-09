using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Users.Queries
{
    public class HasUserTokenQuery: IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid Token { get; set; }

        public class Handler : IRequestHandler<HasUserTokenQuery, bool>
        {
            private readonly IPOSDbContext dbContext;

            public Handler(IPOSDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public Task<bool> Handle(HasUserTokenQuery request, CancellationToken cancellationToken)
            {
                return dbContext.UserToken.AnyAsync(x => x.UserId == request.UserId && x.Token == request.Token);
            }
        }
    }
}
