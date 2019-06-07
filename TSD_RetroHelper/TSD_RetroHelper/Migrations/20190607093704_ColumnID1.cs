using Microsoft.EntityFrameworkCore.Migrations;

namespace TSD_RetroHelper.Migrations
{
    public partial class ColumnID1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColumnId",
                table: "RetroItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnId",
                table: "RetroItem");
        }
    }
}
