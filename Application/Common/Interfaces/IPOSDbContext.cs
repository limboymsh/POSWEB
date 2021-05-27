using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Application.Common.Interfaces
{
    public interface IPOSDbContext
    {
        DbSet<User> User { get; set; }
    }
}
