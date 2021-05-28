using Application.Common.Interfaces;
using Application.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Auth
{
    public class GetUserByEmailAndPassword
    {
        public class GetUsersByEmailAndPasswordQuery : IRequest<User>
        {
            public string Email { get; set; }
            public string Pass { get; set; }
        }
        public class Handler : IRequestHandler<GetUsersByEmailAndPasswordQuery, User>
        {
            private readonly IMediator mediator;
            private readonly IPOSDbContext dbContext;

            public Handler(IMediator mediator, IPOSDbContext dbContext)
            {
                this.mediator = mediator;
                this.dbContext = dbContext;
            }
            public async Task<User> Handle(GetUsersByEmailAndPasswordQuery request, CancellationToken cancellationToken)
            {
                User user = await dbContext.Users.SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
                if (user != null && request.Pass == user.Password)
                {
                    return user;
                }
                throw new EmailOrPasswordNotMatchException();
            }
        }
    }
}
