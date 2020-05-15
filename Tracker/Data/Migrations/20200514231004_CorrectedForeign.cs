using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class CorrectedForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_AspNetUsers_UserId",
                table: "UserProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserProjects_UserId",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProjects");

            migrationBuilder.AlterColumn<string>(
                name: "TrackerUserId",
                table: "UserProjects",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_TrackerUserId",
                table: "UserProjects",
                column: "TrackerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_AspNetUsers_TrackerUserId",
                table: "UserProjects",
                column: "TrackerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_AspNetUsers_TrackerUserId",
                table: "UserProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserProjects_TrackerUserId",
                table: "UserProjects");

            migrationBuilder.AlterColumn<int>(
                name: "TrackerUserId",
                table: "UserProjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserProjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_UserId",
                table: "UserProjects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_AspNetUsers_UserId",
                table: "UserProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
