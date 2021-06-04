
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IPOSDbContext
    {
        DbSet<Inventory> Inventory { get; set; }
        DbSet<InventoryAdjustment> InventoryAdjustment { get; set; }
        DbSet<InventoryCategory> InventoryCategory { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderDeduction> OrderDeduction { get; set; }
        DbSet<OrderDetail> OrderDetail { get; set; }
        DbSet<OrderTable> OrderTable { get; set; }
        DbSet<OtherTransaction> OtherTransaction { get; set; }
        DbSet<Reservation> Reservation { get; set; }
        DbSet<ReservationDetail> ReservationDetail { get; set; }
        DbSet<ReservationTable> ReservationTable { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<RoleModule> RoleModule { get; set; }
        DbSet<Table> Table { get; set; }
        DbSet<TableDetail> TableDetail { get; set; }
        DbSet<Transaction> Transaction { get; set; }
        DbSet<TransactionDetail> TransactionDetail { get; set; }
        DbSet<TransactionDetailDiscount> TransactionDetailDiscount { get; set; }
        DbSet<TransactionDetailPromos> TransactionDetailPromos { get; set; }
        DbSet<TransactionExtraCost> TransactionExtraCost { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserOutlet> UserOutlet { get; set; }
        DbSet<UserRole> UserRole { get; set; }

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        void CommitTransaction();
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        void RollbackTransaction();
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}