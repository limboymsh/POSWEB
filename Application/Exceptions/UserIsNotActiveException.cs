using Domain.Entities;
using System;

namespace Application.Exceptions
{
    public class UserIsNotActiveException : Exception
    {
        public UserIsNotActiveException(string email)
            : base($"Pengguna {email} tidak aktif")
        { }

        public UserIsNotActiveException(User user)
            : base($"Pengguna {user.Email} tidak aktif")
        { }
    }
}
