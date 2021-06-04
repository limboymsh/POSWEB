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
                    Name = table.Column<string>(nullable: true),
                    PromoId = table.Column<Guid>(nullable: true),
                    DiscountId = table.Column<Guid>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    IsActive = table.Column<int>(nullable: false),
                    IsServices = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
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
                    Note = table.Column<string>(nullable: true),
                    IsReduce = table.Column<byte>(nullable: false),
                    IsIncrease = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAdjustment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    OrderTypeId = table.Column<byte>(nullable: true),
                    OutletId = table.Column<Guid>(nullable: true),
                    ReservationId = table.Column<Guid>(nullable: true),
                    OtherTransactionId = table.Column<Guid>(nullable: true),
                    TableId = table.Column<Guid>(nullable: true),
                    MemberId = table.Column<Guid>(nullable: true),
                    PaymentStatus = table.Column<byte>(nullable: true),
                    Status = table.Column<byte>(nullable: true),
                    Code = table.Column<Guid>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    IsDeduction = table.Column<bool>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDeduction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: true),
                    PromoId = table.Column<Guid>(nullable: true),
                    DiscountId = table.Column<Guid>(nullable: true),
                    Value = table.Column<int>(nullable: true),
                    IsPercentage = table.Column<byte>(nullable: true),
                    Total = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDeduction", x => x.Id);
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
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    PromoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
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
                    IssueDate = table.Column<DateTime>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    PromoId = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReservationId = table.Column<Guid>(nullable: false),
                    InventoryId = table.Column<Guid>(nullable: false),
                    InventoryCategoryId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DiscountId = table.Column<Guid>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false),
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
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    IsActive = table.Column<byte>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModuleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    RoomId = table.Column<Guid>(nullable: true),
                    SubRoomId = table.Column<Guid>(nullable: true),
                    OutletId = table.Column<Guid>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOutlet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOutlet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    OutletId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
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
                    table.PrimaryKey("PK_OrderTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTable_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTable_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TableId = table.Column<Guid>(nullable: true),
                    Status = table.Column<byte>(nullable: true),
                    ChairNumbers = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableDetail_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTable_OrderId",
                table: "OrderTable",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTable_TableId",
                table: "OrderTable",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableDetail_TableId",
                table: "TableDetail",
                column: "TableId");
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
                name: "OrderDeduction");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderTable");

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
                name: "TableDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserOutlet");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Table");
        }
    }
}
