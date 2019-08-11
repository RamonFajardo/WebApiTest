using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTest.Migrations
{
    public partial class ChangedOneRelationshipCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_UsersID",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_UsersID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "UsersID",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CarID",
                table: "Users",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cars_CarID",
                table: "Users",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cars_CarID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CarID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CarID",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UsersID",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UsersID",
                table: "Cars",
                column: "UsersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_UsersID",
                table: "Cars",
                column: "UsersID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
