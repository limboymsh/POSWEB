using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Utils
{
    public static class Authorization
    {
        public static void InjectAuthrization<TSrc, TDest>(this IMappingOperationOptions<TSrc, TDest> opts, Company company, User user) where TDest : class, IAuthorizeCommand where TSrc : class
        {
            opts.AfterMap((src, dest) =>
            {
                dest.Company = company;
                dest.User = user;
            });
        }
        public static void InjectAuthrizationUserOnly<TSrc, TDest>(this IMappingOperationOptions<TSrc, TDest> opts, User user) where TDest : class, IAuthorizeUserOnlyCommand where TSrc : class
        {
            opts.AfterMap((src, dest) =>
            {
                dest.User = user;
            });
        }
    }
}
