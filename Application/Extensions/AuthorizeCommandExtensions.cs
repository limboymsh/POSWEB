using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class AuthorizeCommandExtensions
    {
        public static IAuthorizeCommand ApplyData(this IAuthorizeCommand target, Company company, User user)
        {
            target.Company = company;
            target.User = user;
            return target;
        }
    }
}
