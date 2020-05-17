using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class StatusUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_StatusUpdates_StatusId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_StatusId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "StatusUpdatesId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StatusUpdatesId",
                table: "Ticket",
                column: "StatusUpdatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_StatusUpdates_StatusUpdatesId",
                table: "Ticket",
                column: "StatusUpdatesId",
                principalTable: "StatusUpdates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_StatusUpdates_StatusUpdatesId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_StatusUpdatesId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "StatusUpdatesId",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StatusId",
                table: "Ticket",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_StatusUpdates_StatusId",
                table: "Ticket",
                column: "StatusId",
                principalTable: "StatusUpdates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
