using Microsoft.EntityFrameworkCore.Migrations;

namespace TSD_RetroHelper.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetroBoardRefId",
                table: "RetroItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RetroItem_RetroBoardRefId",
                table: "RetroItem",
                column: "RetroBoardRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RetroItem_RetroBoard_RetroBoardRefId",
                table: "RetroItem",
                column: "RetroBoardRefId",
                principalTable: "RetroBoard",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetroItem_RetroBoard_RetroBoardRefId",
                table: "RetroItem");

            migrationBuilder.DropIndex(
                name: "IX_RetroItem_RetroBoardRefId",
                table: "RetroItem");

            migrationBuilder.DropColumn(
                name: "RetroBoardRefId",
                table: "RetroItem");
        }
    }
}
