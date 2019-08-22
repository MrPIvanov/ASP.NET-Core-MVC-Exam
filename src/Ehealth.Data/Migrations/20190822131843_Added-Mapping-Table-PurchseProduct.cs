using Microsoft.EntityFrameworkCore.Migrations;

namespace Ehealth.Data.Migrations
{
    public partial class AddedMappingTablePurchseProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Purchases_PurchaseId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_PurchaseId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PurchaseId",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Purchases",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PurchaseProducts",
                columns: table => new
                {
                    PurchaseId = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseProducts", x => new { x.ProductId, x.PurchaseId });
                    table.ForeignKey(
                        name: "FK_PurchaseProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseProducts_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProducts_PurchaseId",
                table: "PurchaseProducts",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseProducts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PurchaseId",
                table: "Products",
                column: "PurchaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Purchases_PurchaseId",
                table: "Products",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
