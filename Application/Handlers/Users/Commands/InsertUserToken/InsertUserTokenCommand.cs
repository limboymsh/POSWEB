
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Users.Commands.InsertUserToken
{
    public class InsertUserTokenCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Token { get; set; }

        public class Handler : IRequestHandler<InsertUserTokenCommand>
        {
            private readonly IPOSDbContext dbContext;
            
            private readonly IHttpUserRequest httpUserRequest;

            public Handler(IPOSDbContext dbContext, IHttpUserRequest httpUserRequest)
            {
                this.dbContext = dbContext;
                this.httpUserRequest = httpUserRequest;
            }
            public async Task<Unit> Handle(InsertUserTokenCommand request, CancellationToken cancellationToken)
            {
                await dbContext.UserToken.AddAsync(new UserToken
                {
                    UserId = request.UserId,
                    Token = request.Token,
                    CreatedAt = DateTime.Now,
                    IpAddress = httpUserRequest.IpAddress
                }, cancellationToken);
                await dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;

            }
        }
    }
}
