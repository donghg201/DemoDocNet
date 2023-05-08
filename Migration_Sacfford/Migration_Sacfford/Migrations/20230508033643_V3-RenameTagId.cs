using Microsoft.EntityFrameworkCore.Migrations;

namespace Migration_Sacfford.Migrations
{
    public partial class V3RenameTagId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagIdNew",
                table: "tags",
                newName: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "tags",
                newName: "TagIdNew");
        }
    }
}
