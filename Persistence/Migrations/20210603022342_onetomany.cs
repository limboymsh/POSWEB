using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inventory_InventoryCategoryId",
                table: "Inventory",
                column: "InventoryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_InventoryCategory_InventoryCategoryId",
                table: "Inventory",
                column: "InventoryCategoryId",
                principalTable: "InventoryCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_InventoryCategory_InventoryCategoryId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_InventoryCategoryId",
                table: "Inventory");
        }
    }
}
