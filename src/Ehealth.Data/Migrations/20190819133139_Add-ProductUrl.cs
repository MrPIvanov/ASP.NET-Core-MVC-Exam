using Microsoft.EntityFrameworkCore.Migrations;

namespace Ehealth.Data.Migrations
{
    public partial class AddProductUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductUrl",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductUrl",
                table: "Products");
        }
    }
}
