
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Users.Queries
{
    public class GetUserByEmail
    {
        public class GetUserByEmaliQuery : IRequest<User>
        {
            public string Email { get; set; }
        }

        public class GetUserByEmaliQueryHandler : IRequestHandler<GetUserByEmaliQuery, User>
        {
            private readonly IPOSDbContext dbContext;

            public GetUserByEmaliQueryHandler(IPOSDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<User> Handle(GetUserByEmaliQuery request, CancellationToken cancellationToken)
            {
                return await dbContext.User.SingleOrDefaultAsync(x => x.Email == request.Email);
            }
        }
    }
}
