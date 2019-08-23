using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ehealth.Data.Migrations
{
    public partial class AddedMessageModelSendOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SendOn",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendOn",
                table: "Messages");
        }
    }
}
