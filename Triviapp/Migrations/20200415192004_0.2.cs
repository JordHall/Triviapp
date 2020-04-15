using Microsoft.EntityFrameworkCore.Migrations;

namespace Triviapp.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Quiz",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Visibility = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_AccountID",
                table: "Quiz",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Account_AccountID",
                table: "Quiz",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Account_AccountID",
                table: "Quiz");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_AccountID",
                table: "Quiz");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Quiz");
        }
    }
}
