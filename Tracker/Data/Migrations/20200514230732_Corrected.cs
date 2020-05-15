using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracker.Data.Migrations
{
    public partial class Corrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Projects_ProjectId",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UserProjects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "UserProjects",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Projects_ProjectId",
                table: "UserProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Projects_ProjectId",
                table: "UserProjects");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "UserProjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "UserProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Projects_ProjectId",
                table: "UserProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
