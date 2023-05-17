using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class MigratonTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SuperiorEmpId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AssignedBranchId",
                table: "Employees",
                column: "AssignedBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OpenBranchId",
                table: "Accounts",
                column: "OpenBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OpenEmpId",
                table: "Accounts",
                column: "OpenEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branchs_OpenBranchId",
                table: "Accounts",
                column: "OpenBranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Employees_OpenEmpId",
                table: "Accounts",
                column: "OpenEmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Branchs_AssignedBranchId",
                table: "Employees",
                column: "AssignedBranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branchs_OpenBranchId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Employees_OpenEmpId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Branchs_AssignedBranchId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AssignedBranchId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_OpenBranchId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_OpenEmpId",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "SuperiorEmpId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
