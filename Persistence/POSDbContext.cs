using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Persistence
{
    public partial class POSDbContext : DbContext, IPOSDbContext
    {
        private IDbContextTransaction currentContextTransaction = null;
        public POSDbContext()
        {
        }

        public POSDbContext(DbContextOptions<POSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryAdjustment> InventoryAdjustment { get; set; }
        public virtual DbSet<InventoryCategory> InventoryCategory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDeduction> OrderDeduction { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderTable> OrderTable { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<ReservationDetail> ReservationDetail { get; set; }
        public virtual DbSet<ReservationTable> ReservationTable { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleModule> RoleModule { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserOutlet> UserOutlet { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=POS;Trusted_Connection=True;");
            }
        }

       

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            currentContextTransaction = await Database.BeginTransactionAsync(cancellationToken);
            return currentContextTransaction;
        }

        public void CommitTransaction()
        {
            if (currentContextTransaction != null)
            {
                currentContextTransaction.Commit();
            }
            DisposeCurrentTransaction();
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (currentContextTransaction != null)
            {
                await currentContextTransaction.CommitAsync(cancellationToken);
            }
            await DisposeCurrentTransactionAsync();
        }

        public void RollbackTransaction()
        {
            if (currentContextTransaction != null)
            {
                currentContextTransaction.Rollback();
            }
            UndoingChanges();
            DisposeCurrentTransaction();
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (currentContextTransaction != null)
            {
                await currentContextTransaction.RollbackAsync(cancellationToken);
            }
            UndoingChanges();
            await DisposeCurrentTransactionAsync();
        }

        private void DisposeCurrentTransaction() => currentContextTransaction?.Dispose();

        private async Task DisposeCurrentTransactionAsync()
        {
            if (currentContextTransaction != null) await currentContextTransaction.DisposeAsync();
        }

        private void UndoingChanges()
        {
            //https://stackoverflow.com/a/33901817/10372836
            foreach (EntityEntry entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted)
                .ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }
    }
}
