using Application.Common.Interfaces;
using Application.Exceptions;
using Application.Extensions;
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
    public class GetUserQuery : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<GetUserQuery, User>
        {
            private readonly IPOSDbContext dbContext;
            //private readonly IHashing hashing;

            public Handler(IPOSDbContext dbContext)
            {
                this.dbContext = dbContext;
                //this.hashing = hashing;
            }
            public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                User user = await dbContext.User.Include(r => r.UserRole).ThenInclude(r=>r.Role).SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
                if (user != null && !user.Password.IsNullOrEmpty() && user.Password == request.Password)
                {
                    if (!user.UserRole.Role.IsActive) throw new UserIsNotActiveException(user);

                    return user;
                }
                throw new EmailOrPasswordNotMatchException();
            }
        }
    }
}
