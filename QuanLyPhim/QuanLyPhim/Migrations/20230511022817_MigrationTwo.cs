using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyPhim.Migrations
{
    public partial class MigrationTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CateId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CateId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CateId",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "CateId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CateId",
                table: "Movies",
                column: "CateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CateId",
                table: "Movies",
                column: "CateId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
