using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class MigrationThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AccTransactions_ExecutionBranchId",
                table: "AccTransactions",
                column: "ExecutionBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AccTransactions_TellerEmpId",
                table: "AccTransactions",
                column: "TellerEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccTransactions_Branchs_ExecutionBranchId",
                table: "AccTransactions",
                column: "ExecutionBranchId",
                principalTable: "Branchs",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccTransactions_Employees_TellerEmpId",
                table: "AccTransactions",
                column: "TellerEmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccTransactions_Branchs_ExecutionBranchId",
                table: "AccTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccTransactions_Employees_TellerEmpId",
                table: "AccTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AccTransactions_ExecutionBranchId",
                table: "AccTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AccTransactions_TellerEmpId",
                table: "AccTransactions");
        }
    }
}
