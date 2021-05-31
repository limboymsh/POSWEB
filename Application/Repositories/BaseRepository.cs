using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IPOSDbContext dbContext;

        public BaseRepository(IPOSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
