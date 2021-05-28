using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.Users.Commands.CreateUser
{
    /*class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        public CreateUserCommandHandler(IPOSDbContext dbContext, IMediator mediator, IDateTime dateTime, IHashing hashing)
        {
             
        }
        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }*/
}


/*namespace Bis.Application.Handlers.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IBisDbContext context;
        private readonly IMediator mediator;
        private readonly IDateTime dateTime;
        private readonly IHashing hashing;
        public CreateUserCommandHandler(
            IBisDbContext context,
            IMediator mediator,
            IDateTime dateTime,
            IHashing hashing)
        {
            this.context = context;
            this.mediator = mediator;
            this.dateTime = dateTime;
            this.hashing = hashing;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.UseSqlTransaction) await context.BeginTransactionAsync(cancellationToken);


                if (await context.Users.AnyAsync(x => x.Email == request.Email, cancellationToken))
                {
                    // user with this email already registered
                    throw new InsertUserWithSameEmailException(request.Email);
                }

                string referralId = string.Empty;

                //generate new unique referralId
                while (true)
                {
                    referralId = RandomUtils.RandomString(6).ToLower();

                    if (!(await context.Users.AnyAsync(x => x.ReferralId == referralId, cancellationToken)))
                    {
                        break;
                    }
                }

                var user = new User()
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    CreatedAt = dateTime.Now,
                    IsActive = true,
                    EmailVerified = false,
                    Picture = request.Picture,
                    ReferralId = referralId
                };

                if (!string.IsNullOrEmpty(request.GoogleUserId) || request.AutoVerifyEmail)
                {
                    // if create user with google account, auto verified email address
                    user.UserGoogleId = request.GoogleUserId;
                    user.EmailVerified = true;
                    user.EmailVerifiedAt = dateTime.Now;
                }


                if (!string.IsNullOrEmpty(request.Password))
                {
                    user.Password = hashing.HashPassword(request.Password);
                }

                context.Users.Add(user);
                await context.SaveChangesAsync(cancellationToken);

                #region Insert Referral
                if (!string.IsNullOrEmpty(request.ReferralId))
                {
                    var referralUser = await context.Users.FirstOrDefaultAsync(x => x.ReferralId == request.ReferralId.ToLower(), cancellationToken);

                    if (referralUser == null) throw new Exception("Kode Referal tidak valid");

                    user.UserReferralId = referralUser.ReferralId;
                    await context.SaveChangesAsync(cancellationToken);
                }
                #endregion

                await mediator.Send(new VerifyEmailCommand { UserId = user.Id }, cancellationToken);

                await mediator.Send(new InsertActivityCommand(user, $"User berhasil register{(string.IsNullOrEmpty(request.GoogleUserId) ? string.Empty : " menggunakan google")}"), cancellationToken);

                if (request.UseSqlTransaction) context.CommitTransaction();

                return user.Id;
            }
            catch (Exception)
            {
                if (request.UseSqlTransaction) await context.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
}*/