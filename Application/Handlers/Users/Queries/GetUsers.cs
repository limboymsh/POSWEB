using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Users.Queries
{
    public class GetUsers
    {
        public class GetUsersQuery : IRequest<List<User>> { }

        public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<User>>
        {
            private readonly IPOSDbContext dbContext;

            public GetUsersHandler(IPOSDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                var res = await dbContext.User.ToListAsync();
                return res;
            }
        }

    }
}
