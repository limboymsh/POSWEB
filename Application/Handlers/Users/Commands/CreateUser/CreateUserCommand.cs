using MediatR;
using System;

namespace Application.Handlers.Users.Commands.CreateUser
{

    public class CreateUserCommand: CreateUserRequest, IRequest<Guid>
    {
        public bool UseSqlTransaction { get; set; } = true;
        public bool AutoVerifyEmail { get; set; } = false;
    }

    public class CreateUserRequest
    {
        public string Emali { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ReferralId { get; set; }
    }
}