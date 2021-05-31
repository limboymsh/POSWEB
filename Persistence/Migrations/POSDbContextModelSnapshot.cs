﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(POSDbContext))]
    partial class POSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("DiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InventoryCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("IsServices")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<Guid>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PromoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Domain.Entities.InventoryAdjustment", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InventoryCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("IsIncrease")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsReduce")
                        .HasColumnType("tinyint");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<Guid>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("datetime");

                    b.ToTable("InventoryAdjustment");
                });

            modelBuilder.Entity("Domain.Entities.InventoryCategory", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime");

                    b.Property<Guid>("CreatedOn")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<Guid>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedBy")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UpdatedOn")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("InventoryCategory");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<string>("Address")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<Guid?>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("IsDeduction")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("IssueDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<Guid?>("OrderTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OtherTransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("PaymentStatus")
                        .HasColumnType("tinyint");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<Guid?>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("money");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Domain.Entities.OrderDeduction", b =>
                {
                    b.Property<Guid?>("DiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("IsPercentage")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PromoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Total")
                        .HasColumnType("int");

                    b.Property<int?>("Value")
                        .HasColumnType("int");

                    b.ToTable("OrderDeduction");
                });

            modelBuilder.Entity("Domain.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InventoryCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int>("PromoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Domain.Entities.OrderTable", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("OrderTable");
                });

            modelBuilder.Entity("Domain.Entities.OrderType", b =>
                {
                    b.Property<Guid?>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.ToTable("OrderType");
                });

            modelBuilder.Entity("Domain.Entities.Reservation", b =>
                {
                    b.Property<Guid?>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<Guid>("DiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<Guid>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PromoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("datetime");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Domain.Entities.ReservationDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DiscountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InventoryCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<Guid?>("PromoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("ReservationDetail");
                });

            modelBuilder.Entity("Domain.Entities.ReservationTable", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Status")
                        .HasColumnName("status")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("ReservationTable");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte?>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Domain.Entities.RoleModule", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.ToTable("RoleModule");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Notes")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(12)")
                        .HasMaxLength(12)
                        .IsUnicode(false);

                    b.Property<string>("Pin")
                        .HasColumnType("varchar(6)")
                        .HasMaxLength(6)
                        .IsUnicode(false);

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Domain.Entities.UserOutlet", b =>
                {
                    b.Property<Guid>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("UserOutlet");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OutletId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("RoleId")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.ToTable("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}
