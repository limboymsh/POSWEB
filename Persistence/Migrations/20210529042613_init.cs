using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false),
                    InventoryCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PromoId = table.Column<Guid>(nullable: true),
                    DiscountId = table.Column<Guid>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    IsActive = table.Column<int>(nullable: false),
                    IsServices = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryAdjustment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false),
                    InventoryCategoryId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Note = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IsReduce = table.Column<byte>(nullable: false),
                    IsIncrease = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "InventoryCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CreatedOn = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedOn = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: true),
                    OrderTypeId = table.Column<Guid>(nullable: true),
                    OutletId = table.Column<Guid>(nullable: true),
                    ReservationId = table.Column<Guid>(nullable: true),
                    OtherTransactionId = table.Column<Guid>(nullable: true),
                    TableId = table.Column<Guid>(nullable: true),
                    RoomId = table.Column<Guid>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: true),
                    PaymentStatus = table.Column<byte>(nullable: true),
                    Status = table.Column<byte>(nullable: true),
                    Code = table.Column<Guid>(nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    IsDeduction = table.Column<byte>(nullable: true),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Note = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OrderDeduction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true),
                    PromoId = table.Column<Guid>(nullable: true),
                    DiscountId = table.Column<Guid>(nullable: true),
                    Value = table.Column<int>(nullable: true),
                    IsPercentage = table.Column<byte>(nullable: true),
                    Total = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false),
                    InventoryCategoryId = table.Column<Guid>(nullable: false),
                    DiscountId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    PromoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    TableId = table.Column<Guid>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false),
                    DiscountId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false),
                    Code = table.Column<Guid>(nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PromoId = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ReservationDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReservationId = table.Column<Guid>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false),
                    InventoryCategoryId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DiscountId = table.Column<Guid>(nullable: true),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    PromoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReservationId = table.Column<Guid>(nullable: false),
                    TableId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: true),
                    RoleName = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    IsActive = table.Column<byte>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "RoleModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModuleName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Pin = table.Column<string>(unicode: false, maxLength: 6, nullable: true),
                    Notes = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserOutlet",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryAdjustment");

            migrationBuilder.DropTable(
                name: "InventoryCategory");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderDeduction");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderTable");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "ReservationDetail");

            migrationBuilder.DropTable(
                name: "ReservationTable");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RoleModule");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserOutlet");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
