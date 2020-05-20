using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class commentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrackerUserId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TrackerUserId",
                table: "Comments",
                column: "TrackerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_TrackerUserId",
                table: "Comments",
                column: "TrackerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_TrackerUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TrackerUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TrackerUserId",
                table: "Comments");
        }
    }
}
