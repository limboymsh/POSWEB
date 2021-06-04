using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class TransactionRepository :BaseRepository
    {
        public TransactionRepository(IPOSDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Transaction>> getTransactionByOutlet(Guid outletId)
        {
            return await dbContext.Transaction.Where(x => x.OutletId == outletId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> getTransactionsByDateRange(Guid outletId,DateTime fromDate, DateTime toDate)
        {
            return await dbContext.Transaction.Where(x => x.OutletId == outletId && x.CreatedOn >= fromDate && x.CreatedOn <= toDate).ToListAsync();
        }
    }
}
