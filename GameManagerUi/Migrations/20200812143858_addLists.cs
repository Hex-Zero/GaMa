using Microsoft.EntityFrameworkCore.Migrations;

namespace GameManagerUi.Migrations
{
    public partial class addLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "GameManagers");

            migrationBuilder.AddColumn<int>(
                name: "GameManagerId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GameManagerId",
                table: "Teams",
                column: "GameManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_GameManagers_GameManagerId",
                table: "Teams",
                column: "GameManagerId",
                principalTable: "GameManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_GameManagers_GameManagerId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_GameManagerId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GameManagerId",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "GameManagers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
