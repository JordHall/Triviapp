using Microsoft.EntityFrameworkCore.Migrations;

namespace Triviapp.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Account_AccountID",
                table: "Quiz");

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                table: "Quiz",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Account_AccountID",
                table: "Quiz",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Account_AccountID",
                table: "Quiz");

            migrationBuilder.AlterColumn<int>(
                name: "AccountID",
                table: "Quiz",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Account_AccountID",
                table: "Quiz",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
