using Application.Common.Interfaces;
using Application.Repositories.Response;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class InventoryRepository : BaseRepository
    {
        public InventoryRepository(IPOSDbContext dbContext) : base(dbContext)
        {
            
        }
        // Inventory
        // Get inventory by id
        public async Task<Inventory> GetInventoryById(Guid id)
        {
            var inventory = await dbContext.Inventory.Include(b => b.InventoryCategory).SingleOrDefaultAsync(x => x.Id == id);
            return inventory;
        }

        // Get inventory by outlet
        public async Task<IEnumerable<Inventory>> GetInventoriesByOutlet(Guid outletId)
        {
            var inventories = await dbContext.Inventory.Include(b => b.InventoryCategory).Where(i => i.OutletId == outletId).ToListAsync();
            return inventories;
        }

        // Get inventories by company
        public async Task<IEnumerable<Inventory>> GetInventoriesByCompany(Guid companyId)
        {
            var inventories = await dbContext.Inventory.Include(b => b.InventoryCategory).Where(i => i.CompanyId == companyId).ToListAsync();
            return inventories;
        }


        // Inventory Category
        // Get inventory category by id
        public async Task<InventoryCategory> GetInventoryCategoryById(Guid id)
        {
            return await dbContext.InventoryCategory.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<InventoryCategory>> GetInventoryCategoriesByOutlet(Guid outletId)
        {
            return await dbContext.InventoryCategory.Where(i => i.Id == outletId).Include(i =>i.Inventory).ToListAsync();
        }


        // Inventory Adjustment
        // Get all inventory adjustment
        public async Task<IEnumerable<InventoryAdjustment>> GetInventoryAdjustments()
        {
            return await dbContext.InventoryAdjustment.ToListAsync();
        }

        // Get inventory by id
        public async Task<InventoryAdjustment> GetInventoryAdjustmentById(Guid id)
        {
            return await dbContext.InventoryAdjustment.SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<InventoryAdjustment>> GetInventoryAdjustmentsByOutlet(Guid outletId)
        {
            return await dbContext.InventoryAdjustment.Where(i => i.Id == outletId).ToListAsync();
        }
        
    }
}
