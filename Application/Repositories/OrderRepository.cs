using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class OrderRepository : BaseRepository
    {
        public OrderRepository(IPOSDbContext dbContext) : base(dbContext)
        {

        }
        // Get order by id
        public async Task<Order> getOrderById(Guid id)
        {
            return await dbContext.Order.SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Order> getOrderDetail(Guid id)
        {
            return await dbContext.Order.Include(x => x.OrderTable).Include(x => x.OrderDeduction).Include(x => x.OrderDetail).ThenInclude(y => y.Inventory).ThenInclude(z => z.InventoryCategory).SingleOrDefaultAsync(x => x.Id == id);
        }

        // Get orders by outlet
        public async Task<IEnumerable<Order>> getOrdersByOutlet(Guid outletId)
        {
            return await dbContext.Order.Include(x => x.OrderTable).Where(x => x.OutletId == outletId).ToListAsync();
        }

        // Get order by outlet & by type
        public async Task<IEnumerable<Order>> getOrdersByOutletAndByOrderType(Guid outletId, OrderType orderType)
        {
            return await dbContext.Order.Include(x => x.OrderTable).Where(x => x.OutletId == outletId && x.OrderTypeId == orderType).ToListAsync();
        }

    }
}
