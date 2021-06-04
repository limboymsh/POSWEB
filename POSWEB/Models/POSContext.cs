using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebUI.Models
{
    public partial class POSContext : DbContext
    {
        public POSContext()
        {
        }

        public POSContext(DbContextOptions<POSContext> options)
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
        public virtual DbSet<OtherTransaction> OtherTransaction { get; set; }
        public virtual DbSet<Ppob> Ppob { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<ReservationDetail> ReservationDetail { get; set; }
        public virtual DbSet<ReservationTable> ReservationTable { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleModule> RoleModule { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<TableDetail> TableDetail { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetail { get; set; }
        public virtual DbSet<TransactionDetailDiscount> TransactionDetailDiscount { get; set; }
        public virtual DbSet<TransactionDetailPromos> TransactionDetailPromos { get; set; }
        public virtual DbSet<TransactionExtraCost> TransactionExtraCost { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserOutlet> UserOutlet { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=POS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<InventoryAdjustment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<InventoryCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderDeduction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TotalPrice).HasColumnType("money");
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OtherTransaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Ppob>(entity =>
            {
                entity.ToTable("PPOB");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ReservationDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TotalPrice).HasColumnType("money");
            });

            modelBuilder.Entity<ReservationTable>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoleModule>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TableDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TransactionDetailDiscount>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.Value).HasColumnType("money");
            });

            modelBuilder.Entity<TransactionDetailPromos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.Value).HasColumnType("money");
            });

            modelBuilder.Entity<TransactionExtraCost>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Value).HasColumnType("money");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserOutlet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
