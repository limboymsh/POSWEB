using Application.Common.Interfaces;
using Application.Repositories.Response;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class InventoryCategoryRepository : BaseRepository
    {
        public InventoryCategoryRepository(IPOSDbContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<IEnumerable<InventoryCategory>> GetAllInventryCategory()
        {
            return await dbContext.InventoryCategory.ToListAsync();
        }

        public async Task AddInventoryCategory(InventoryCategory category)
        {
            try
            {
                
                await dbContext.InventoryCategory.AddAsync(category);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await dbContext.RollbackTransactionAsync();
            }
            
        }
    }
}
